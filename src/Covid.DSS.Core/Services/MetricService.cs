using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Configuration;
using Covid.DSS.Common.Infrastructure;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;
using Covid.DSS.Core.Repositories.Interfaces;
using Covid.DSS.Core.Services.Interfaces;

namespace Covid.DSS.Core.Services
{
    public class MetricService : ServiceBase<MetricDatabaseSettings>, IMetricService
    {
        private readonly IExcelReaderService _excelReaderService;
        private readonly IHospitalUnitRepository _hospitalUnitRepository;
        private readonly IHospitalDataTemplateRepository _dataTemplateRepository;
        private readonly IHospitalMetricRequestRepository _metricRequestRepository;
        private readonly IHospitalMetricRepository _metricRepository;
        private readonly UserIdentityContext _userIdentityContext;

        public MetricService(IMetricDatabaseContext context, IExcelReaderService excelReaderService,
            IHospitalUnitRepository hospitalUnitRepository, IHospitalDataTemplateRepository dataTemplateRepository,
            IHospitalMetricRequestRepository metricRequestRepository, IHospitalMetricRepository metricRepository,
            UserIdentityContext userIdentityContext) : base(context)
        {
            _excelReaderService = excelReaderService;
            _hospitalUnitRepository = hospitalUnitRepository;
            _dataTemplateRepository = dataTemplateRepository;
            _metricRequestRepository = metricRequestRepository;
            _metricRepository = metricRepository;
            _userIdentityContext = userIdentityContext;
        }

        public async Task Import(byte[] file, int templateId)
        {
            DatabaseContext.BeginTransaction();

            var metricRequestCreateRequest = await _metricRequestRepository.CreateRequest(templateId, new HospitalMetricRequestCreateRequest
            {
                UserId = _userIdentityContext.GetUserId(),
                Status = MetricRequestStatusType.Pending
            });

            if (metricRequestCreateRequest == null)
            {
                DatabaseContext.TryRollbackTransaction();
                throw new TransactionFailureException();
            }

            var setup = await GetTemplateSetup(templateId);

            var parsedMetrics = _excelReaderService.ParseFile(file, setup);
            var decoratedMetrics = await DecorateMetrics(metricRequestCreateRequest.Id, parsedMetrics);

            foreach (var decoratedMetric in decoratedMetrics)
            {
                var createdMetric = await _metricRepository.CreateMetric(new HospitalMetricCreateRequest
                {
                    RequestId = metricRequestCreateRequest.Id,
                    UnitId = decoratedMetric.UnitId,
                    RegionId = decoratedMetric.RegionId,
                    TypeId = decoratedMetric.TypeId,
                    Value = decoratedMetric.Value,
                    Status = decoratedMetric.Status,
                    Type = decoratedMetric.Type,
                    EffectiveDate = decoratedMetric.EffectiveDate
                });
            }

            DatabaseContext.TryCommitTransaction();
        }

        public async Task<HospitalTemplateSetup> GetTemplateSetup(int templateId)
        {
            var setup = await _dataTemplateRepository.GetDataTemplate(templateId);
            var metricSetups = await GetTemplateMetricSetups(templateId);

            var result = new HospitalTemplateSetup
            {
                Id = setup.Id,
                Name = setup.Name,
                HeaderRows = setup.HeaderRows,
                MetricSetups = metricSetups,
            };

            return result;
        }

        public async Task<IEnumerable<HospitalTemplateMetricSetup>> GetTemplateMetricSetups(int templateId)
        {
            var metricTypes = await GetMetricTypes();

            if (metricTypes == null || !metricTypes.Any())
                return null;

            var dataTemplateMetrics = await _dataTemplateRepository.GetDataTemplateMetrics(templateId);

            var result = new List<HospitalTemplateMetricSetup>();

            foreach (var dataTemplateMetric in dataTemplateMetrics)
            {
                var matchingMetricType = metricTypes.FirstOrDefault(x => x.Id == dataTemplateMetric.MetricTypeId);

                if(matchingMetricType == null)
                    continue;

                var templateMetricSetup = new HospitalTemplateMetricSetup
                {
                    DataTemplateId = templateId,
                    MetricTypeId = matchingMetricType.Id,
                    Source = dataTemplateMetric.Source,
                    SourceType = dataTemplateMetric.SourceType,

                    MetricType = matchingMetricType
                };

                result.Add(templateMetricSetup);
            }

            return result;
        }

        public async Task<IEnumerable<HospitalMetricType>> GetMetricTypes()
        {
            return await _dataTemplateRepository.GetMetricTypes();
        }

        private async Task<IEnumerable<HospitalMetric>> DecorateMetrics(int requestId, IEnumerable<HospitalMetric> metrics)
        {
            var hospitalUnits = await _hospitalUnitRepository.GetHospitalUnits();

            foreach (var metric in metrics)
            {
                var matchingHospital = hospitalUnits.FirstOrDefault(x => x.Id == metric.UnitId);
                metric.RequestId = requestId;
                metric.RegionId = matchingHospital?.Region ?? 0;
                metric.Status = MetricStatusType.Active;
                metric.Type = MetricType.Draft;
                metric.InsertDate = DateTime.Now;
            }

            return metrics;
        }
    }
}

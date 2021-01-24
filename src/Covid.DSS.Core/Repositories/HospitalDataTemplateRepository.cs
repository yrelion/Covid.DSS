using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Infrastructure;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;
using Covid.DSS.Common.Utilities;
using Covid.DSS.Core.Repositories.Interfaces;
using Dapper;

namespace Covid.DSS.Core.Repositories
{
    public class HospitalDataTemplateRepository : DapperQueryHandler, IHospitalDataTemplateRepository
    {
        private const string DateTemplatesTable = "hospital_data_templates";
        private const string DateTemplateMetricsTable = "hospital_data_template_metrics";
        private const string MetricTypesTable = "metric_types";

        public HospitalDataTemplateRepository(IMetricDatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<HospitalDataTemplate> GetDataTemplate(int id)
        {
            return await QueryFirstAsync<HospitalDataTemplate>(Resources.Queries.Select_ById.FormatWith(DateTemplatesTable),
                new DynamicParameters(), (parameters, options) =>
                {
                    parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                });
        }

        public async Task<IEnumerable<HospitalDataTemplateMetric>> GetDataTemplateMetrics(int templateId)
        {
            return await QueryAsync<HospitalDataTemplateMetric>(Resources.Queries.Select_DataTemplateMetrics_ByTemplateId.FormatWith(DateTemplateMetricsTable),
                new DynamicParameters(), (parameters, options) =>
                {
                    parameters.Add("@ID", templateId, DbType.Int32, ParameterDirection.Input);
                });
        }

        public async Task<IEnumerable<HospitalMetricType>> GetMetricTypes()
        {
            return await QueryAsync<HospitalMetricType>(Resources.Queries.Select_AllRecords.FormatWith(MetricTypesTable));
        }
    }
}

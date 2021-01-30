using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;
using Indice.Types;

namespace Covid.DSS.Core.Services.Interfaces
{
    public interface IMetricService
    {
        Task<ResultSet<HospitalMetric>> GetMetrics(ListOptions<HospitalMetricFilter> options);
        Task<IEnumerable<HospitalMetricType>> GetMetricTypes();
        Task<HospitalMetricRequestContext> CreateImportRequest(byte[] file, int templateId);
        Task<HospitalMetricRequestContext> GetImportRequestContext(int requestId);
        Task<HospitalMetricRequestContext> ApproveImportRequest(int requestId);
        Task<HospitalMetricRequestContext> RejectImportRequest(int requestId);
        Task<HospitalTemplateSetup> GetTemplateSetup(int templateId);
        Task<IEnumerable<HospitalTemplateMetricSetup>> GetTemplateMetricSetups(int templateId);
    }
}

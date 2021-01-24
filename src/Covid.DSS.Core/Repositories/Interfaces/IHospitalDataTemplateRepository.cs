using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Models.DTO;

namespace Covid.DSS.Core.Repositories.Interfaces
{
    public interface IHospitalDataTemplateRepository
    {
        Task<HospitalDataTemplate> GetDataTemplate(int id);
        Task<IEnumerable<HospitalDataTemplateMetric>> GetDataTemplateMetrics(int templateId);
        Task<IEnumerable<HospitalMetricType>> GetMetricTypes();
    }
}

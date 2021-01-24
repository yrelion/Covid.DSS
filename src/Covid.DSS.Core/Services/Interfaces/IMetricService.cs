using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;

namespace Covid.DSS.Core.Services.Interfaces
{
    public interface IMetricService
    {
        Task Import(byte[] file, int templateId);
        Task<HospitalTemplateSetup> GetTemplateSetup(int templateId);
        Task<IEnumerable<HospitalTemplateMetricSetup>> GetTemplateMetricSetups(int templateId);
        Task<IEnumerable<HospitalMetricType>> GetMetricTypes();
    }
}

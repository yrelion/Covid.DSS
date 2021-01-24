using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;
using Indice.Types;

namespace Covid.DSS.Core.Repositories.Interfaces
{
    public interface IHospitalMetricRepository
    {
        Task<IEnumerable<HospitalMetric>> GetMetrics(ListOptions options = null);
        Task<HospitalMetric> GetMetric(int id);
        Task<IEnumerable<HospitalMetric>> GetMetricsByRequestId(ListOptions options = null);
        Task<HospitalMetric> CreateMetric(HospitalMetricCreateRequest request);
    }
}

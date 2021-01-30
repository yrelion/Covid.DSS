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
        Task<ResultSet<HospitalMetric>> GetMetrics(ListOptions<HospitalMetricFilter> options = null);
        Task<HospitalMetric> GetMetric(int id);
        Task<IEnumerable<HospitalMetric>> GetMetricsByRequestId(int requestId, ListOptions options = null);
        Task<HospitalMetric> CreateMetric(HospitalMetricCreateRequest request);
        Task<IEnumerable<HospitalMetric>> UpdateMetricsTypeByRequestId(int requestId, HospitalMetricUpdateTypeRequest request);
    }
}

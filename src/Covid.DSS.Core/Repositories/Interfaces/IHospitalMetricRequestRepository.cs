using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;
using Indice.Types;

namespace Covid.DSS.Core.Repositories.Interfaces
{
    public interface IHospitalMetricRequestRepository
    {
        Task<IEnumerable<HospitalMetricRequest>> GetRequests(ListOptions options = null);
        Task<HospitalMetricRequest> GetRequest(int id);
        Task<HospitalMetricRequest> CreateRequest(int templateId, HospitalMetricRequestCreateRequest request);
    }
}

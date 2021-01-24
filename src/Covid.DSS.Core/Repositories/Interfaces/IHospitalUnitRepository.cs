using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Models.DTO;
using Indice.Types;

namespace Covid.DSS.Core.Repositories.Interfaces
{
    public interface IHospitalUnitRepository
    {
        Task<IEnumerable<HospitalUnit>> GetHospitalUnits(ListOptions options = null);
    }
}

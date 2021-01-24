using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Covid.DSS.Common.Infrastructure;
using Covid.DSS.Common.Models;
using Covid.DSS.Common.Models.DTO;
using Covid.DSS.Common.Utilities;
using Covid.DSS.Core.Repositories.Interfaces;
using Dapper;
using Indice.Types;

namespace Covid.DSS.Core.Repositories
{
    public class HospitalUnitRepository : DapperQueryHandler, IHospitalUnitRepository
    {
        private const string Table = "hospital_units";

        public HospitalUnitRepository(IMetricDatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<HospitalUnit>> GetHospitalUnits(ListOptions options = null)
        {
            return await QueryAsync<HospitalUnit>(Resources.Queries.Select_AllRecords.FormatWith(Table), options: options);
        }
    }
}

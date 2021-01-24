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
using Indice.Types;

namespace Covid.DSS.Core.Repositories
{
    public class HospitalMetricRequestRepository : DapperQueryHandler, IHospitalMetricRequestRepository
    {
        private const string Table = "hospital_metrics_requests";

        public HospitalMetricRequestRepository(IMetricDatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<HospitalMetricRequest>> GetRequests(ListOptions options = null)
        {
            return await QueryAsync<HospitalMetricRequest>(Resources.Queries.Select_AllRecords.FormatWith(Table), options: options);
        }

        public async Task<HospitalMetricRequest> GetRequest(int id)
        {
            return await QueryFirstAsync<HospitalMetricRequest>(Resources.Queries.Select_ById.FormatWith(Table), new DynamicParameters(),
                (parameters, options) =>
                {
                    parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                });
        }

        public async Task<HospitalMetricRequest> CreateRequest(int templateId, HospitalMetricRequestCreateRequest request)
        {
            var parameters = new DynamicParameters();

            await ExecuteProcedureAsync("Create_Metrics_Request", parameters, dynamicParameters =>
            {
                parameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@TEMPLATEID", templateId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@USERID", request.UserId, DbType.String, ParameterDirection.Input);
                parameters.Add("@INSERTDATE", DateTime.Now, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@STATUS", request.Status.ToString(), DbType.String, ParameterDirection.Input);
            });

            var requestId = parameters.Get<int>("ID");

            return await GetRequest(requestId);
        }
    }
}

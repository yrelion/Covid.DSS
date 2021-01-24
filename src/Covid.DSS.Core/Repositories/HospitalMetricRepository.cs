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
    public class HospitalMetricRepository : DapperQueryHandler, IHospitalMetricRepository
    {
        private const string Table = "hospital_metrics";

        public HospitalMetricRepository(IMetricDatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<HospitalMetric>> GetMetrics(ListOptions options = null)
        {
            return await QueryAsync<HospitalMetric>(Resources.Queries.Select_AllRecords.FormatWith(Table), options: options);
        }

        public async Task<HospitalMetric> GetMetric(int id)
        {
            return await QueryFirstAsync<HospitalMetric>(Resources.Queries.Select_ById.FormatWith(Table), new DynamicParameters(),
                (parameters, options) =>
                {
                    parameters.Add("@ID", id, DbType.Int32, ParameterDirection.Input);
                });
        }

        public async Task<IEnumerable<HospitalMetric>> GetMetricsByRequestId(ListOptions options = null)
        {
            return await QueryAsync<HospitalMetric>(Resources.Queries.Select_Metric_ByRequestId.FormatWith(Table), options: options);
        }

        public async Task<HospitalMetric> CreateMetric(HospitalMetricCreateRequest request)
        {
            var parameters = new DynamicParameters();

            await ExecuteProcedureAsync("Create_Metric", parameters, dynamicParameters =>
            {
                parameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@REQUESTID", request.RequestId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@UNITID", request.UnitId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@REGIONID", request.RegionId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@TYPEID", request.TypeId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@VALUE", request.Value, DbType.String, ParameterDirection.Input);
                parameters.Add("@STATUS", request.Status.ToString(), DbType.String, ParameterDirection.Input);
                parameters.Add("@TYPE", request.Type.ToString(), DbType.String, ParameterDirection.Input);
                parameters.Add("@EFFECTIVEDATE", request.EffectiveDate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@INSERTDATE", DateTime.Now, DbType.DateTime, ParameterDirection.Input);
            });

            var metricId = parameters.Get<int>("ID");

            return await GetMetric(metricId);
        }
    }
}

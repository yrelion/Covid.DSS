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

        public async Task<ResultSet<HospitalMetric>> GetMetrics(ListOptions<HospitalMetricFilter> options = null)
        {
            var sql = Resources.Queries.Select_AllRecords.FormatWith(Table);
            var parameters = new DynamicParameters();

            AddHospitalMetricFiltersToQuery(ref sql, ref parameters, options.Filter);

            return await QueryResultSetAsync<HospitalMetric>(sql, parameters, options: options);
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

        private string ClauseVariant(ref string sql)
        {
            var whereClauseLiteral = " WHERE ";
            var andLiteral = " AND ";

            var containsWhereClause = sql.Contains(whereClauseLiteral);

            return !containsWhereClause ? whereClauseLiteral : andLiteral;
        }

        private void AddHospitalMetricFiltersToQuery(ref string sql, ref DynamicParameters parameters, HospitalMetricFilter filter)
        {
            if (!filter.HasAnyValue())
                return;

            if (filter.RegionId != default(int))
            {
                sql += $"{ClauseVariant(ref sql)}hospital_unit_region_id = @REGIONID";
                parameters.Add("@REGIONID", filter.RegionId, DbType.Int32, ParameterDirection.Input);
            }

            if (filter.UnitId != default(int))
            {
                sql += $"{ClauseVariant(ref sql)}hospital_unit_id = @UNITID";
                parameters.Add("@UNITID", filter.UnitId, DbType.Int32, ParameterDirection.Input);
            }

            if (filter.TypeId != default(int))
            {
                sql += $"{ClauseVariant(ref sql)}metric_type_id = @TYPEID";
                parameters.Add("@TYPEID", filter.TypeId, DbType.Int32, ParameterDirection.Input);
            }

            if (filter.EffectiveDate != null)
            {
                sql += $"{ClauseVariant(ref sql)}effective_date = @EFFECTIVEDATE";
                parameters.Add("@EFFECTIVEDATE", filter.EffectiveDate, DbType.Date, ParameterDirection.Input);
            }
        }
    }
}

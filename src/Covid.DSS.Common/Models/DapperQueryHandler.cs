using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Covid.DSS.DapperWrapper;
using Covid.DSS.DapperWrapper.Interfaces;
using Covid.DSS.DapperWrapper.Models;
using Dapper;
using Serilog;

namespace Covid.DSS.Common.Models
{
    public abstract class DapperQueryHandler : QueryHandler
    {
        protected DapperQueryHandler(IDatabaseContext<IDatabaseSettings> databaseContext) : base(databaseContext) { }

        protected override void HandleException(Exception e)
        {
            Log.Error("Exception: {@e}", e);
            throw new InternalDatabaseException();
        }

        protected override void HandleRollback()
        {
            if (Transaction == null)
                return;

            Transaction.Rollback();
            Log.Warning("[TRANSACTION] Rollback performed");
        }

        protected override void LogSqlQuery(string statement, DynamicParameters parameters) { }

        protected override void LogSqlOperation(string statement, DynamicParameters parameters)
        {
            LogSql(statement, parameters);
        }

        private void LogSql(string statement, DynamicParameters parameters)
        {
            Dictionary<string, object> parameterDictionary = new Dictionary<string, object>();

            foreach (var paramName in parameters.ParameterNames)
            {
                parameterDictionary.Add(paramName, parameters.Get<object>(paramName));
            }

            var serializedParameters = JsonSerializer.Serialize(parameterDictionary,
                new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) });

            Log.Information("[SQL] {$Statement} \n[PARAMS] {$Parameters}", statement, serializedParameters);
        }
    }
}

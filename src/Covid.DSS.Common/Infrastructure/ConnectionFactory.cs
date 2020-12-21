using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Covid.DSS.DapperWrapper.Interfaces;
using Covid.DSS.DapperWrapper.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Covid.DSS.Common.Infrastructure
{
    public class ConnectionFactory<TSettings> : ConnectionFactoryBase<TSettings> where TSettings : class, IDatabaseSettings, new()
    {
        public ConnectionFactory(IOptions<TSettings> options)
        {
            Settings = options.Value;
        }

        public override IDbConnection Create(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        public override IDbConnection CreateFromSettings()
        {
            var connectionString = string.Format(Settings.ConnectionString,
                Settings.Username, Settings.Password);

            return new MySqlConnection(connectionString);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.DapperWrapper.Interfaces;

namespace Covid.DSS.Common.Configuration
{
    public class MySqlSettings
    {
        public const string Name = "MySQL";
        public MetricDatabaseSettings Metric { get; set; }
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }
    }

    public class MetricDatabaseSettings : DatabaseSettings
    {
        public const string Name = "MySQL:Metric";
    }
}

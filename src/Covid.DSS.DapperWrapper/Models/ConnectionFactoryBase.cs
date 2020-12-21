using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Covid.DSS.DapperWrapper.Interfaces;

namespace Covid.DSS.DapperWrapper.Models
{
    public abstract class ConnectionFactoryBase<TSettings> : IConnectionFactory<TSettings> where TSettings : class, IDatabaseSettings, new()
    {
        public IDatabaseSettings Settings { get; set; }
        public abstract IDbConnection Create(string connectionString);
        public abstract IDbConnection CreateFromSettings();
    }
}

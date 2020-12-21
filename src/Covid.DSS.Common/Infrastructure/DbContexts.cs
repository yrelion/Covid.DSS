using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Configuration;
using Covid.DSS.DapperWrapper.Interfaces;

namespace Covid.DSS.Common.Infrastructure
{
    public interface IMetricDatabaseContext : IDatabaseContext<MetricDatabaseSettings> { }

    public class MetricDbContext : DbContext<MetricDatabaseSettings>, IMetricDatabaseContext
    {
        public MetricDbContext(IConnectionFactory<MetricDatabaseSettings> factory) : base(factory) { }
    }
}

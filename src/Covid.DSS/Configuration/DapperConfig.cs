using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.DSS.Core.Configuration;
using Dapper.FluentMap;

namespace Covid.DSS.Configuration
{
    public class DapperConfig
    {
        public static void Initialize()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMetricMaps();
            });
        }
    }
}

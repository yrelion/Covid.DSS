using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Core.Repositories.Mappings;
using Dapper.FluentMap.Configuration;

namespace Covid.DSS.Core.Configuration
{
    public static class MappingConfig
    {
        public static void AddMetricMaps(this FluentMapConfiguration config)
        {
            config.AddMap(new ChartMap());
            config.AddMap(new HospitalDataTemplateMap());
            config.AddMap(new HospitalDataTemplateMetricMap());
            config.AddMap(new HospitalMetricMap());
            config.AddMap(new HospitalMetricRequestMap());
            config.AddMap(new HospitalMetricTypeMap());
            config.AddMap(new MetricTypeThresholdMap());
        }
    }
}

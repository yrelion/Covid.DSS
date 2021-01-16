using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;
using Dapper.FluentMap.Mapping;

namespace Covid.DSS.Core.Repositories.Mappings
{
    public class MetricTypeThresholdMap : EntityMap<MetricTypeThreshold>
    {
        public MetricTypeThresholdMap()
        {
            Map(x => x.MetricTypeId).ToColumn("metric_type_id");
            Map(x => x.ThresholdLevelType).ToColumn("threshold_level");
        }
    }
}

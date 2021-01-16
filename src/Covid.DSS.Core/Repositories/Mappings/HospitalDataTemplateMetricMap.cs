using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;
using Dapper.FluentMap.Mapping;

namespace Covid.DSS.Core.Repositories.Mappings
{
    public class HospitalDataTemplateMetricMap : EntityMap<HospitalDataTemplateMetric>
    {
        public HospitalDataTemplateMetricMap()
        {
            Map(x => x.DataTemplateId).ToColumn("hospital_data_template_id");
            Map(x => x.MetricTypeId).ToColumn("metric_type_id");
            Map(x => x.SourceType).ToColumn("source_type");
        }
    }
}

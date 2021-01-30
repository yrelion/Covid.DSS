using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;
using Dapper.FluentMap.Mapping;

namespace Covid.DSS.Core.Repositories.Mappings
{
    public class HospitalMetricMap : EntityMap<HospitalMetric>
    {
        public HospitalMetricMap()
        {
            Map(x => x.RequestId).ToColumn("hospital_metrics_request_id");
            Map(x => x.UnitId).ToColumn("hospital_unit_id");
            Map(x => x.RegionId).ToColumn("hospital_unit_region_id");
            Map(x => x.TypeId).ToColumn("metric_type_id");
            Map(x => x.EffectiveDate).ToColumn("effective_date");
            Map(x => x.InsertDate).ToColumn("insert_date");
            Map(x => x.UpdateDate).ToColumn("update_date");
            Map(x => x.UpdateUser).ToColumn("update_user");
        }
    }
}

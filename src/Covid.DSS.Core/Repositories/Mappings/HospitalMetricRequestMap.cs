using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;
using Dapper.FluentMap.Mapping;

namespace Covid.DSS.Core.Repositories.Mappings
{
    public class HospitalMetricRequestMap : EntityMap<HospitalMetricRequest>
    {
        public HospitalMetricRequestMap()
        {
            Map(x => x.DataTemplateId).ToColumn("hospital_data_template_id");
            Map(x => x.UserId).ToColumn("user_id");
            Map(x => x.InsertDate).ToColumn("insert_date");
        }
    }
}

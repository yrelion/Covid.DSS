using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;
using Dapper.FluentMap.Mapping;

namespace Covid.DSS.Core.Repositories.Mappings
{
    public class HospitalMetricTypeMap : EntityMap<HospitalMetricType>
    {
        public HospitalMetricTypeMap()
        {
            Map(x => x.ValueType).ToColumn("value_type");
        }
    }
}

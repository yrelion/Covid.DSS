using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;
using Dapper.FluentMap.Mapping;

namespace Covid.DSS.Core.Repositories.Mappings
{
    public class ChartMap : EntityMap<Chart>
    {
        public ChartMap()
        {
            Map(x => x.ChartTypeId).ToColumn("chart_type_id");
        }
    }
}

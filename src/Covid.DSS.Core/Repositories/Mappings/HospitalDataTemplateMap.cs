using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;
using Dapper.FluentMap.Mapping;

namespace Covid.DSS.Core.Repositories.Mappings
{
    public class HospitalDataTemplateMap : EntityMap<HospitalDataTemplate>
    {
        public HospitalDataTemplateMap()
        {
            Map(x => x.HeaderRows).ToColumn("header_rows");
        }
    }
}

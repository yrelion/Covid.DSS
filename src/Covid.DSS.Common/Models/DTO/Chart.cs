using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models.DTO
{
    public class Chart
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ChartTypeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models.DTO
{
    public class HospitalMetricType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ValueType ValueType { get; set; }
    }
}

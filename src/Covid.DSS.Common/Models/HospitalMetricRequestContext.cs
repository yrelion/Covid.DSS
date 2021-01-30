using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;

namespace Covid.DSS.Common.Models
{
    public class HospitalMetricRequestContext
    {
        public HospitalMetricRequest Request { get; set; }
        public IEnumerable<HospitalMetric> Metrics { get; set; }
    }
}

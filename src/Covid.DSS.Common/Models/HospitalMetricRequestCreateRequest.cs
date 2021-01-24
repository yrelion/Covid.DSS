using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models
{
    public class HospitalMetricRequestCreateRequest
    {
        public string UserId { get; set; }
        public MetricRequestStatusType Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models.DTO
{
    public class HospitalMetricRequest
    {
        public int Id { get; set; }
        public int DataTemplateId { get; set; }
        public Guid UserId { get; set; }
        public DateTime InsertDate { get; set; }
        public MetricRequestStatusType Status { get; set; }
    }
}

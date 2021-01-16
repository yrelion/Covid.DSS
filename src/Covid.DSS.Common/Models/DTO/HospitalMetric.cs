using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models.DTO
{
    public class HospitalMetric
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int UnitId { get; set;}
        public int RegionId { get; set; }
        public int TypeId { get; set; }
        public string Value { get; set; }
        public MetricStatusType Status { get; set; }
        public MetricType Type { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}

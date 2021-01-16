using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models.DTO
{
    public class MetricTypeThreshold
    {
        public int Id { get; set; }
        public int MetricTypeId { get; set; }
        public ThresholdLevelType ThresholdLevelType { get; set; }
    }
}

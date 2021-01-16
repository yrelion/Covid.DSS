using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models.DTO
{
    public class HospitalDataTemplateMetric
    {
        public int DataTemplateId { get; set; }
        public int MetricTypeId { get; set; }
        public string Source { get; set; }
        public DataTemplateMetricSourceType SourceType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Common.Models.DTO;

namespace Covid.DSS.Common.Models
{
    public class HospitalTemplateSetup : HospitalDataTemplate
    {
        public IEnumerable<HospitalTemplateMetricSetup> MetricSetups { get; set; }
    }

    public class HospitalTemplateMetricSetup : HospitalDataTemplateMetric
    {
        public HospitalMetricType MetricType { get; set; }
    }
}

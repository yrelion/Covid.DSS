using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models
{
    public enum ThresholdLevelType
    {
        Low = 0,
        High = 5,
        Critical = 10
    }

    public enum ValueType
    {
        Number = 0,
        Text = 1
    }

    public enum MetricStatusType
    {
        Inactive = 0,
        Active = 1
    }

    public enum MetricType
    {
        Draft = 0,
        Final = 1
    }

    public enum MetricRequestStatusType
    {
        Pending = 0,
        Accepted = 1,
        Rejected = 2
    }

    public enum DataTemplateMetricSourceType
    {
        Cell = 0,
        Range = 1,
        Field = 2
    }
}

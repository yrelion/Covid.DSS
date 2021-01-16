using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models
{
    public enum ThresholdLevelType
    {
        Low,
        High,
        Critical
    }

    public enum ValueType
    {
        Number,
        Text
    }

    public enum MetricStatusType
    {
        Active,
        Inactive
    }

    public enum MetricType
    {
        Draft,
        Final
    }

    public enum MetricRequestStatusType
    {
        Pending,
        Accepted,
        Rejected
    }

    public enum DataTemplateMetricSourceType
    {
        Column,
        Cell,
        Field
    }
}

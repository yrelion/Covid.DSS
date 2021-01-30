using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.DSS.Common.Models
{
    public class HospitalMetricFilter
    {
        public int UnitId { get; set; }
        public int RegionId { get; set; }
        public int TypeId { get; set; }
        public DateTime? EffectiveDate { get; set; }

        public bool HasAnyValue()
        {
            if (RegionId != default(int))
                return true;

            if (UnitId != default(int))
                return true;

            if (TypeId != default(int))
                return true;

            if (EffectiveDate != null)
                return true;

            return false;
        }
    }
}

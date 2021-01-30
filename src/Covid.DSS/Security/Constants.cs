using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.DSS.Security
{
    internal abstract class Policies
    {
        public abstract class Metrics
        {
            public abstract class Clearance
            {
                public const string Basic = "metrics:requirements:basic";
                public const string Elevated = "metrics:requirements:elevated";
            }
        }
    }

    internal abstract class Roles
    {
        public const string User = "User";
        public const string Support = "Support";
        public const string Admin = "Admin";
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.DapperWrapper.Interfaces;

namespace Covid.DSS.Common.Models
{
    public class ServiceBase<TSettings> where TSettings : IDatabaseSettings
    {
        protected IDatabaseContext<TSettings> DatabaseContext;

        public ServiceBase(IDatabaseContext<TSettings> context)
        {
            DatabaseContext = context;
        }
    }
}

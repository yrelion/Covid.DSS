using System;
using System.Collections.Generic;
using System.Text;
using Covid.DSS.Core.Services;
using Covid.DSS.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Covid.DSS.Core.Configuration
{
    public static class ServiceCollectionConfig
    {
        public static void AddMetricServices(this IServiceCollection services)
        {
            services.AddServices();
            services.AddRepositories();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IExcelReaderService, ExcelReaderService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {

        }
    }
}

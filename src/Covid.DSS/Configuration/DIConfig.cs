using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.DSS.Common.Configuration;
using Covid.DSS.Common.Infrastructure;
using Covid.DSS.DapperWrapper.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Covid.DSS.Configuration
{
    public static class DIConfig
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Application Settings
            services.Configure<MySqlSettings>(configuration.GetSection(MySqlSettings.Name));
            services.Configure<MetricDatabaseSettings>(configuration.GetSection(MetricDatabaseSettings.Name));
            services.AddSingleton(x => x.GetService<IOptions<MySqlSettings>>()?.Value);
            services.AddSingleton(x => x.GetService<IOptions<MetricDatabaseSettings>>()?.Value);

            // Per Context Connection Factories
            services.AddSingleton<IConnectionFactory<MetricDatabaseSettings>, ConnectionFactory<MetricDatabaseSettings>>();

            // Database Contexts
            services.AddScoped<IMetricDatabaseContext, MetricDbContext>();
        }
    }
}

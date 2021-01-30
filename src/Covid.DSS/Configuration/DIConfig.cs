using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Covid.DSS.Common.Configuration;
using Covid.DSS.Common.Infrastructure;
using Covid.DSS.Common.Models;
using Covid.DSS.Core.Configuration;
using Covid.DSS.DapperWrapper.Interfaces;
using Microsoft.AspNetCore.Http;
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
            services.Configure<ExcelSettings>(configuration.GetSection(ExcelSettings.Name));
            services.AddSingleton(x => x.GetService<IOptions<MySqlSettings>>()?.Value);
            services.AddSingleton(x => x.GetService<IOptions<MetricDatabaseSettings>>()?.Value);
            services.AddSingleton(x => x.GetService<IOptions<ExcelSettings>>()?.Value);

            // Per Context Connection Factories
            services.AddSingleton<IConnectionFactory<MetricDatabaseSettings>, ConnectionFactory<MetricDatabaseSettings>>();

            // Database Contexts
            services.AddScoped<IMetricDatabaseContext, MetricDbContext>();

            // Custom Services
            services.AddMetricServices();

            // Miscellaneous
            services.AddScoped(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddScoped<UserIdentityContext>();
        }
    }
}

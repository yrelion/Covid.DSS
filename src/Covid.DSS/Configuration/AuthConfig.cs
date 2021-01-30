using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.DSS.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Covid.DSS.Configuration
{
    public static class AuthConfig
    {
        public static void ConfigureAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.Metrics.Clearance.Basic, 
                    policy => policy.RequireAuthenticatedUser());
                options.AddPolicy(Policies.Metrics.Clearance.Elevated, 
                    policy => policy.RequireRole(Roles.Admin, Roles.Support));
            });
        }
    }
}

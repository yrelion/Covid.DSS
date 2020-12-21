using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.DSS.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Covid.DSS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            Log.Logger = LoggingConfig.ConfigureLogger();

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog(Log.Logger);
        }
    }
}

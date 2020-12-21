using System;
using System.Threading;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;

namespace Covid.DSS.Configuration
{
    public static class LoggingConfig
    {
        /// <summary>
        /// Configures the <see cref="Logger"/>
        /// </summary>
        public static Logger ConfigureLogger()
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Information()

                .Enrich.FromLogContext()
                .Enrich.With<SequenceIdEnricher>()
                .Enrich.WithExceptionDetails()

                .WriteTo.Console()
                .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Month)
                .CreateLogger();

            Log.Logger = logger;

            return logger;
        }
    }

    public class SequenceIdEnricher : ILogEventEnricher
    {
        private long _currentId;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException("logEvent");

            var incrementedId = Interlocked.Increment(ref _currentId);
            logEvent.AddPropertyIfAbsent(new LogEventProperty("SequenceId", new ScalarValue(incrementedId)));
        }
    }
}

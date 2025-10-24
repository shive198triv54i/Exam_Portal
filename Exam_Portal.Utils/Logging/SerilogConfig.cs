using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
//using Serilog.Extensions.Hosting;


namespace Exam_Portal.Utils.Logging
{
    public static class SerilogConfig
    {
        public static void ConfigureSerilog(IHostBuilder hostBuilder, IConfiguration configuration)
        {
            hostBuilder.UseSerilog((context, loggerConfig) =>
            {
                //loggerConfig
                //    .ReadFrom.Configuration(configuration)
                //    .Enrich.FromLogContext()
                //    .WriteTo.Console()
                //    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day);
            });
        }
    }
}

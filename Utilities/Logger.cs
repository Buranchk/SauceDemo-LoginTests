using Serilog;
using Serilog.Events;

namespace TestLogs
{
    public static class Logger
    {
        public static readonly ILogger Log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("/Users/gurban/RiderProjects/SauceDemo-logintests/Logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
}
using System.Diagnostics;
using System.Reflection;
using Serilog;
using Serilog.Events;

namespace TestLogs
{
    public static class Logger
    {
        private static readonly string AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        private static readonly string SolutionPath = Path.GetFullPath(
            Path.Combine(AssemblyPath!, "..", "..", "..")
        );
        
        public static readonly string docPath = Path.Combine(SolutionPath, "Logs", "logs.txt");

        static Logger()
        {
            var logDir = Path.GetDirectoryName(docPath);
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
        }

        public static readonly ILogger Log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(docPath, rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
}
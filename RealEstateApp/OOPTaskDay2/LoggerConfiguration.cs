using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace OOPTaskDay2
{
    public static class LoggerConfig
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Error() // Only log Error and Fatal event
                 .WriteTo.File(
                     path: "Logs/log-.txt",
                     restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error, // Log only errors in the file
                     rollingInterval: RollingInterval.Day,
                     outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}",
                     retainedFileCountLimit: 7
                 )
                 .CreateLogger();
        }
    }
}

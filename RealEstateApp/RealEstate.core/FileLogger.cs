using System.Configuration;

namespace RealEstate.core
{
    public static class FileLogger
    {
        public static void Log(string message)
        {
            try
            {
                // Retrieve the log directory path from App.config
                string logDirectory = ConfigurationManager.AppSettings["logPath"];


                // Expand environment variables (e.g., %APPDATA%)
                logDirectory = Environment.ExpandEnvironmentVariables(logDirectory);


                // Ensure the directory exists
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }


                // Generate log file name in YYYYMMDD.txt format
                string logFileName = $"{DateTime.Now:yyyyMMdd}.txt";
                string logFilePath = Path.Combine(logDirectory, logFileName);


                // Write the message to the log file with a timestamp
                File.AppendAllText(logFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // If an error occurs while logging, show the error in the console
                Console.WriteLine($"Failed to log message: {ex.Message}");
            }
        }
    }
}

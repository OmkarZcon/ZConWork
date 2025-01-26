using System;
using System.IO;
using System.Configuration;


namespace OOPTaskDay2
{
    public static class FileLogger
    {
        public static void Log(string message)
        {
            try
            {
                // Retrieve the log path from App.config
                string logPath = ConfigurationManager.AppSettings["logPath"];

                // If log path is empty or null, fallback to default path
                if (string.IsNullOrEmpty(logPath))
                {
                    Console.WriteLine("Log path not defined in App.config. Using default path.");
                    logPath = "log.txt"; // Default log file path
                }

                // Write the message to the log file with a timestamp
                File.AppendAllText(logPath, $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                // If an error occurs while logging, show the error in the console
                Console.WriteLine($"Failed to log message: {ex.Message}");
            }
        }
    }
}

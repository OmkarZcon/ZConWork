namespace OOPTaskDay2
{
    public static class FileLogger
    {
        public static void Log(string message)
        {
            try
            {
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

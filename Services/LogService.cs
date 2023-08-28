namespace ErrorHandling.Services
{
    public class LogService
    {
        public ILogger<LogService> _logger { get; set; }
        public LogService(ILogger<LogService> logger)
        {
            Console.WriteLine("LogService");
            this._logger = logger;
        }

        public void Write(string message)
        {
            this._logger.LogInformation(message);
        }
    }
}

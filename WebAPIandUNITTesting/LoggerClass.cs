using Microsoft.Extensions.Logging;

namespace WebAPI
{
    class LoggerClass
    {
        private readonly ILogger _logger;

        public LoggerClass(ILogger<LoggerClass> logger)
        {
            _logger = logger;
        }

        public void SomeMethod(int count)
        {
            _logger.LogInformation("Count using logger : " + count);
        }
        public void SomeMethodMsg(string message)
        {
            _logger.LogInformation("Message using logger : " + message);
        }
        public void Error(string message)
        {
            _logger.LogInformation("Error : " + message);
        }

    }
}

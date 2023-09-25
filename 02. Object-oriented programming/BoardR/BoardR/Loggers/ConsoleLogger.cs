using BoardR.Loggers.Contracts;

namespace BoardR.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string value)
        {
            Console.WriteLine(value);
        }
    }
}

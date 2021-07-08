using System;
namespace InterfaceExtensibility
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
        }

        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }

    }
}

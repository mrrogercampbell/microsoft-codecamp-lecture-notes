using System;
namespace InterfaceExtensibility
{
    public interface ILogger
    {
        void LogError(string message);
        void LogInfo(string message);
    }
}

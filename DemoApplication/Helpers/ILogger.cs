using System;

namespace ClearCut.Helpers
{
    public interface ILogger
    {
        void LogError(string message, Exception ex = null);
    }
}
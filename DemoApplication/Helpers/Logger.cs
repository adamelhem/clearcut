using System;
using System.Diagnostics;

namespace ClearCut.Helpers
{
    public class Logger : ILogger
    {
        //TODO upgrade this further
        public void LogError(string message, Exception ex = null)
        {
            Debug.WriteLine($"{message} , {ex}");
        }
    }
}

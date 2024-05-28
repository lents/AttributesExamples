using System.Diagnostics;

namespace ConditionalAttributes
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Logger.Debug("This is a debug message.");
            Logger.Trace("This is a trace message.");
            Logger.AlwaysLog("This is a regular log message.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

using System.Diagnostics;

namespace ConditionalAttributes
{
        public class Logger
        {
            [Conditional("DEBUG")]
            public static void Debug(string message)
            {
                Console.WriteLine($"DEBUG: {message}");
            }

            [Conditional("TRACE")]
            public static void Trace(string message)
            {
                Console.WriteLine($"TRACE: {message}");
            }
            
            [Obsolete()]
            public static void AlwaysLog(string message)
            {
                Console.WriteLine($"LOG: {message}");
            }
        }
    }

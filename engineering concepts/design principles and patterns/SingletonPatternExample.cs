using System;

namespace SingletonPatternExample
{
    public sealed class Logger
    {
        // Step 1: private static instance of itself
        private static Logger? _instance = null;

        // Lock object to make instance creation thread-safe
        private static readonly object _lock = new object();

        // Step 2: private constructor prevents external instantiation
        private Logger()
        {
            Console.WriteLine("Logger instance created.");
        }

        // Step 3: public static method to get the single instance
        public static Logger GetInstance()
        {
            // Double-checked locking for thread safety
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        // Example logging functionality
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }

    // ---- Test Class with entry point ----
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Requesting first Logger instance...");
            Logger logger1 = Logger.GetInstance();
            logger1.Log("First log message.");

            Console.WriteLine();
            Console.WriteLine("Requesting second Logger instance...");
            Logger logger2 = Logger.GetInstance();
            logger2.Log("Second log message.");

            bool isSameInstance = ReferenceEquals(logger1, logger2);
            Console.WriteLine();
            Console.WriteLine($"Are logger1 and logger2 the same instance? {isSameInstance}");
        }
    }
}

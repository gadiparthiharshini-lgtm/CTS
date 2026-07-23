using System;

namespace SingletonPatternExample
{
    public class Logger
    {
        // Static instance of Logger
        private static Logger? instance;

        // Private constructor
        private Logger()
        {
            Console.WriteLine("Logger Instance Created");
        }

        // Public method to access the single instance
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }

            return instance;
        }

        // Logging method
        public void Log(string message)
        {
            Console.WriteLine("Log: " + message);
        }
    }
}
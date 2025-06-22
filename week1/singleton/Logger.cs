using System;

public class Logger
{
    private static Logger instance;
    private static readonly object lockObj = new object();

    // Private constructor ensures it can't be instantiated outside
    private Logger()
    {
        Console.WriteLine("Logger initialized.");
    }

    // Public method to get the instance
    public static Logger GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
            }
        }
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

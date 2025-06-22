using System;

class Program
{
    static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("This is the first log message.");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("This is the second log message.");

        Console.WriteLine($"logger1 and logger2 refer to the same instance: {object.ReferenceEquals(logger1, logger2)}");
    }
}

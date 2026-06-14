using System;

public sealed class Logger
{
    private static Logger instance;

    private Logger()
    {
    }

    public static Logger GetInstance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }

        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class Program
{
    static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        Console.WriteLine(
            ReferenceEquals(logger1, logger2));
    }
}
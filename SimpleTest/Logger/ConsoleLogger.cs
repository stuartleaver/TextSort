namespace SimpleTest.Logger;

public class ConsoleLogger : ILogger
{
    public void Log(string stuff)
    {
        Console.WriteLine(stuff);
    }
}
using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();

        // Subscribe to events
        stopwatch.OnStarted += DisplayMessage;
        stopwatch.OnStopped += DisplayMessage;
        stopwatch.OnReset += DisplayMessage;

        Console.WriteLine("Console Stopwatch Application");
        Console.WriteLine("Press 'S' to Start, 'T' to Stop, 'R' to Reset, 'Q' to Quit.");

        while (true)
        {
            var input = Console.ReadKey(intercept: true).KeyChar;

            switch (char.ToUpper(input))
            {
                case 'S':
                    Task.Run(() => stopwatch.Start());
                    break;
                case 'T':
                    stopwatch.Stop();
                    break;
                case 'R':
                    stopwatch.Reset();
                    break;
                case 'Q':
                    Console.WriteLine("Exiting the application.");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please press 'S', 'T', 'R', or 'Q'.");
                    break;
            }
        }
    }

    static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}
using System;
using System.Threading;

public class Stopwatch
{
    public TimeSpan TimeElapsed { get; private set; }
    private bool isRunning;

    // Declare events using a delegate
    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    public void Start()
    {
        if (isRunning) return;

        isRunning = true;
        OnStarted?.Invoke("Stopwatch Started!");

        while (isRunning)
        {
            Thread.Sleep(1000);
            TimeElapsed = TimeElapsed.Add(TimeSpan.FromSeconds(1));
            Console.WriteLine($"Time Elapsed: {TimeElapsed}");
        }
    }

    public void Stop()
    {
        if (!isRunning) return;

        isRunning = false;
        OnStopped?.Invoke("Stopwatch Stopped!");
    }

    public void Reset()
    {
        TimeElapsed = TimeSpan.Zero;
        isRunning = false;
        OnReset?.Invoke("Stopwatch Reset!");
    }
}

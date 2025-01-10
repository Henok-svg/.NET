using System;
using System.Threading.Tasks;
using System.Threading;

public class StopWatch
{
    public TimeSpan TimeTaken { get; private set; } = TimeSpan.Zero;
    private bool _isRunning = false;
    private CancellationTokenSource? _cancellationTokenSource;

    public delegate void StopWatchEventHandler(string message);
    public event StopWatchEventHandler? OnStarted;
    public event StopWatchEventHandler? OnStopped;
    public event StopWatchEventHandler? OnReset;

    public delegate void TimeUpdatedHandler(TimeSpan time);
    public event TimeUpdatedHandler? OnTimeUpdated;

    public void Begin()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _cancellationTokenSource = new CancellationTokenSource();
            OnStarted?.Invoke("StopWatch Started");
            Task.Run(() => Tick(_cancellationTokenSource.Token));
        }
    }

    public void Stop()
    {
        if (_isRunning)
        {
            _isRunning = false;
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
            string stopMessage = $"StopWatch Stopped\nTime Elapsed: {TimeTaken:mm\\:ss}";
            OnStopped?.Invoke(stopMessage);
        }
    }

    public void Reset()
    {
        Stop();
        TimeTaken = TimeSpan.Zero;
        OnReset?.Invoke("StopWatch Reset!");
    }

    private async Task Tick(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(1000, token);
                TimeTaken = TimeTaken.Add(TimeSpan.FromSeconds(1));
                OnTimeUpdated?.Invoke(TimeTaken);
            }
        }
        catch (TaskCanceledException)
        {
        }
    }
}

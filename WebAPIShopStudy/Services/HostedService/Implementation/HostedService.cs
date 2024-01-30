using System.Diagnostics;

namespace WebAPIShopStudy.Services.HostedService.Implementation;

public class HostedService : IHostedService, IDisposable {
   
    private int executionCount = 0;
    private Timer? _timer = null;


    public Task StartAsync(CancellationToken stoppingToken) {
        Debug.WriteLine("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(3));

        return Task.CompletedTask;
    }

    private void DoWork(object? state) {
        var count = Interlocked.Increment(ref executionCount);

        Debug.WriteLine(
            "Vlad is toxic!\nTimed Hosted Service is working. Count: " + count);
    }

    public Task StopAsync(CancellationToken stoppingToken) {
        Debug.WriteLine("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose() {
        _timer?.Dispose();
    }
}

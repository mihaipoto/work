using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Aplicatie.Infrastructure;

public class Muncitor : IHostedService
{
    private readonly ILogger<Muncitor> _logger;

    public Muncitor(ILogger<Muncitor> logger)
    {
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("stop");
        return Task.CompletedTask;
    }

    protected async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {

            _logger.LogInformation("muncitor");
            await Task.Delay(1000);
        }
    }
}

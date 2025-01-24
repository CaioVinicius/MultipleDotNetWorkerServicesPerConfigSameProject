namespace Poc.Vertem.Crons.Services
{
    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;

        public WorkerService(ILogger<WorkerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("WorkerServiceA iniciado.");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("WorkerServiceA em execução: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

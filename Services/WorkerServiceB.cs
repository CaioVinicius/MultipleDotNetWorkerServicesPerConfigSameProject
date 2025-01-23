namespace Poc.Vertem.Crons.Services
{
    public class WorkerServiceB : BackgroundService
    {
        private readonly ILogger<WorkerServiceA> _logger;

        public WorkerServiceB(ILogger<WorkerServiceA> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("WorkerServiceB iniciado.");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("WorkerServiceB em execução: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

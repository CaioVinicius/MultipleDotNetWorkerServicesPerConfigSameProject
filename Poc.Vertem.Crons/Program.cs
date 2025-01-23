using Poc.Vertem.Crons.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables();
    })
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        var workerName = Environment.GetEnvironmentVariable("WORKER_NAME")?? configuration["WorkerSettings:WorkerName"];
        Console.WriteLine($"WORKER_NAME: {workerName}");

        switch (workerName)
        {
            case "WorkerServiceA":
                Console.WriteLine("Registrando WorkerServiceA...");
                services.AddHostedService<WorkerServiceA>();
                break;
            case "WorkerServiceB":
                Console.WriteLine("Registrando WorkerServiceB...");
                services.AddHostedService<WorkerServiceB>();
                break;
            default:
                Console.WriteLine("WORKER_NAME não definido ou inválido.");
                throw new InvalidOperationException("WORKER_NAME não definido ou inválido.");
        }
    })
    .ConfigureLogging(logging =>
    {
        logging.AddConsole();
    })
    .Build();

await host.RunAsync();
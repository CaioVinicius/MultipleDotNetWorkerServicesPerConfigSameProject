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
        var horario = Environment.GetEnvironmentVariable("HORARIO") ?? configuration["WorkerSettings:Horario"];
        Console.WriteLine($"WORKER_NAME: {workerName}");
        Console.WriteLine($"HORARIO: {horario}");

        Console.WriteLine("Registrando WorkerService...");
        services.AddHostedService<WorkerService>();
    })
    .ConfigureLogging(logging =>
    {
        logging.AddConsole();
    })
    .Build();

await host.RunAsync();
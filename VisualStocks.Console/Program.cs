using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VisualStocks.Console;

IHost host = Host
    .CreateDefaultBuilder(args)

    .ConfigureServices(services =>
    {
        services.AddSingleton<IHostedService, ConsoleApp>();
    })
    .Build();

host.RunAsync();
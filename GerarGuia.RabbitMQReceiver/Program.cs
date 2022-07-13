using GerarGuia.ApiClient.Interface;
using GerarGuia.ApiClient.Services;
using GerarGuia.Domain.Shared.Configuration;
using GerarGuia.RabbitMQReceiver;
using GerarGuia.RabbitMQReceiver.Receivers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json");

        var configuration = configurationBuilder.Build();
        services.Configure<RabbitMqConfiguration>(configuration.GetSection("RabbitMqConfig"));
        services.Configure<ClientApiConfiguration>(configuration.GetSection("ClientApiConfiguration"));

        services.AddHostedService<GuiaReceiver>();
        services.AddTransient<IApiClientService, ApiClientService>();
        services.AddTransient<IGuiaService, GuiaService>();


    })
    .Build();

await host.RunAsync();

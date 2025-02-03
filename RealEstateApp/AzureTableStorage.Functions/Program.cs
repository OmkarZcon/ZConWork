using Azure.Data.Tables;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddSingleton((s) =>
        {
            string storageConnectionString = "UseDevelopmentStorage=true";
            return new TableClient(storageConnectionString, "Properties");
        });
    })
    .Build();

host.Run();
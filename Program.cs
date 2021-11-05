using GitpodTest;
using GitpodTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => {        
        services.AddHostedService<Worker>();
        services.AddDbContextFactory<Database>(options => {
            options.UseSqlServer(context.Configuration.GetConnectionString("sqlserver"));
        });
    })
    .Build();

await host.RunAsync();

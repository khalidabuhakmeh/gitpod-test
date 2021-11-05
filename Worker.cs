using GitpodTest.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GitpodTest;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    private readonly IDbContextFactory<Database> factory;

    public Worker(ILogger<Worker> logger, IDbContextFactory<Database> factory)
    {
        this.logger = logger;
        this.factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var db = factory.CreateDbContext())
             {
                var number = new RandomNumber {
                    Value = RandomNumberGenerator.GetInt32(Int32.MaxValue)
                };

                db.Numbers.Add(number);
                await db.SaveChangesAsync();

                logger.LogInformation(
                    "Random num #{Id} has a value of {Value} ({Time})",
                    number.Id, number.Value, number.CreatedAt
                );

                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}

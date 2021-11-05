using Microsoft.EntityFrameworkCore;

namespace GitpodTest.Models;

public class Database : DbContext 
{
    public Database(DbContextOptions options)
            :base(options)
    {
    }

    public DbSet<RandomNumber> Numbers {get;set;} = null!;
}

public class RandomNumber 
{
    public int Id {get;set;}
    public int Value {get;set;}
    public DateTimeOffset CreatedAt {get;set;} = DateTimeOffset.UtcNow;
}

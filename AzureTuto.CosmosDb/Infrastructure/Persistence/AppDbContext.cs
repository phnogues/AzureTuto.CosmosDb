using AzureTuto.CosmosDb.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureTuto.CosmosDb.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(f =>
        {
            f.ToContainer("users");
            f.Property(f => f.Id).ToJsonProperty("id");
            f.Property(f => f.Username).ToJsonProperty("username");
            f.Property(f => f.GroupID).ToJsonProperty("groupID");
            f.Property(f => f.LastModified).ToJsonProperty("lastModified");
            f.HasNoDiscriminator();
            f.HasDefaultTimeToLive(60 * 60 * 24 * 30);
            f.HasPartitionKey(p => p.GroupID);
            f.HasKey(vote => vote.Id);
        });
    }
}

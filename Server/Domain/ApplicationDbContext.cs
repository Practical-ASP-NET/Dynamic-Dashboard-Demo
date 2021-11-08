using DynamicDashboards.Server.Domain.Dashboards;
using Microsoft.EntityFrameworkCore;

namespace DynamicDashboards.Server.Domain;

public class ApplicationDbContext : DbContext
{
    public DbSet<Dashboard> Dashboards { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dashboard>()
            .HasMany<Panel>();
    }

}
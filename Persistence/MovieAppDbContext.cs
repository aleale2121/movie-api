using Domain.Entites;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Persistence;

public class MOVIEAPPDbContext : DbContext
{
    public MOVIEAPPDbContext(DbContextOptions<MOVIEAPPDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MOVIEAPPDbContext).Assembly);
    }

    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Movie> Movies { get; set; }

    public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
    {
        // foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
        //     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        // {
        //     entry.Entity.LastModifiedDate = DateTime.Now;
        //     entry.Entity.LastModifiedBy = username;

        //     if (entry.State == EntityState.Added)
        //     {
        //         entry.Entity.DateCreated = DateTime.Now;
        //         entry.Entity.CreatedBy = username;
        //     }
        // }

        var result = await base.SaveChangesAsync();

        return result;
    }
}


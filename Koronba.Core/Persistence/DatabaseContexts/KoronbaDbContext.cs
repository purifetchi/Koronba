using Koronba.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Koronba.Core.Persistence.DatabaseContexts;

/// <summary>
/// The Koronba models.
/// </summary>
public class KoronbaDbContext : DbContext
{
    /// <summary>
    /// The flashes db set.
    /// </summary>
    public DbSet<Flash> Flashes { get; set; }
    
    /// <summary>
    /// The tags db set.
    /// </summary>
    public DbSet<Tag> Tags { get; set; } 

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flash>()
            .OwnsMany(f => f.KnownNames);

        modelBuilder.Entity<Flash>()
            .OwnsOne(f => f.Metadata);

        modelBuilder.Entity<Flash>()
            .HasMany(f => f.Tags)
            .WithMany(t => t.Flashes);
    }
}
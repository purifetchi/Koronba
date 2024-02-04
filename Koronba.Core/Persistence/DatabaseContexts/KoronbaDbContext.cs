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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Koronba.db");
    }

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
        
        modelBuilder.Entity<Tag>()
            .HasIndex(t => t.Name)
            .IsUnique();

        modelBuilder.Entity<Tag>()
            .HasData(
                new Tag { Id = Guid.NewGuid(), Name = "Aww" },
                new Tag { Id = Guid.NewGuid(), Name = "Lol" },
                new Tag { Id = Guid.NewGuid(), Name = "Wtf" },
                new Tag { Id = Guid.NewGuid(), Name = "Classic" },
                new Tag { Id = Guid.NewGuid(), Name = "Cool" },
                new Tag { Id = Guid.NewGuid(), Name = "Loop" },
                new Tag { Id = Guid.NewGuid(), Name = "Game" },
                new Tag { Id = Guid.NewGuid(), Name = "Misc" });
    }
}
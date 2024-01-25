using Koronba.Core.Models;
using Koronba.Core.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace Koronba.Core.Persistence.Repositories;

/// <summary>
/// The tag repository.
/// </summary>
public class TagRepository : ITagRepository
{
    /// <summary>
    /// The database context for tags.
    /// </summary>
    private readonly KoronbaDbContext _db;

    /// <summary>
    /// Constructs a new tag repository.
    /// </summary>
    /// <param name="db">The database context for tags.</param>
    public TagRepository(KoronbaDbContext db)
    {
        _db = db;
    }
    
    /// <inheritdoc/>
    public async Task<Tag> Create(Tag tag)
    {
        var result = await _db.AddAsync(tag);
        return result.Entity;
    }

    /// <inheritdoc/>
    public async Task<Tag?> FindByName(string name)
    {
        var result = await _db.Tags
            .Where(t => t.Name == name)
            .FirstOrDefaultAsync();

        return result;
    }
}
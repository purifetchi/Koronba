using Koronba.Core.Models;
using Koronba.Core.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace Koronba.Core.Persistence.Repositories;

/// <summary>
/// The flash entry repository.
/// </summary>
/// <remarks>
/// Constructs a new flash entry repository.
/// </remarks>
/// <param name="db">The database context.</param>
public class FlashRepository(KoronbaDbContext db) 
    : IFlashRepository
{
    /// <summary>
    /// The db context.
    /// </summary>
    private readonly KoronbaDbContext _db = db;

    /// <inheritdoc/>
    public async Task<Flash> AddEntry(Flash flash)
    {
        var result = await _db.AddAsync(flash);
        await _db.SaveChangesAsync();
        return result.Entity;
    }

    /// <inheritdoc/>
    public async Task<bool> Update(Flash flash)
    {
        _db.Update(flash);
        return await _db.SaveChangesAsync() == 1;
    }

    /// <inheritdoc/>
    public async Task<Flash?> FindById(int id)
    {
        var result = await _db.Flashes
            .Where(f => f.Id == id)
            .FirstOrDefaultAsync();

        return result;
    }

    /// <inheritdoc/>
    public async Task<Flash?> FindByFileHash(string hash)
    {
        var result = await _db.Flashes
            .Where(f => f.Hash == hash)
            .FirstOrDefaultAsync();

        return result;
    }

    /// <inheritdoc/>
    public async Task<List<Flash>> FindAllContainingName(string name)
    {
        var result = await _db.Flashes
            .Where(f => f.KnownNames
                .Any(n => n.Name.Contains(name)))
            .ToListAsync();

        return result;
    }

    /// <inheritdoc/>
    public async Task<List<Flash>> GetLastSeen(int count)
    {
        var result = await _db.Flashes
            .OrderByDescending(f => f.LastSeenAt)
            .Take(count)
            .ToListAsync();

        return result;
    }

    /// <inheritdoc/>
    public async Task<List<Flash>> GetNewest(int count)
    {
        var result = await _db.Flashes
            .OrderByDescending(f => f.CreatedAt)
            .Take(count)
            .ToListAsync();

        return result;
    }
}
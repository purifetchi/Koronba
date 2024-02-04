using Koronba.Core.Configuration;
using Koronba.Core.Models;
using Microsoft.Extensions.Options;

namespace Koronba.Core.Persistence.Stores;

/// <summary>
/// A disk-backed thumbnail store.
/// </summary>
/// <param name="config">The thumbnail config path.</param>
public class DiskThumbnailStore(IOptions<KoronbaCoreConfiguration> config) : IThumbnailStore
{
    /// <summary>
    /// The path to the store.
    /// </summary>
    private readonly string _storePath = config.Value
        .ThumbnailStorePath;

    /// <inheritdoc/>
    public Stream? GetThumbnailStreamFor(Flash flash)
    {
        var path = Path.Combine(_storePath, $"{flash.Hash}.png");
        
        return !File.Exists(path) ? 
            null : 
            new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
    }

    /// <inheritdoc/>
    public async Task<bool> StoreThumbnail(Flash flash, Stream stream)
    {
        var path = Path.Combine(_storePath, $"{flash.Hash}.png");
        await using var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        await stream.CopyToAsync(fs);
        
        return true;
    }
}
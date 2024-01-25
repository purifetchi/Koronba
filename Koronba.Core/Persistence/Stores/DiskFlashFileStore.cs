using Koronba.Core.Configuration;
using Koronba.Core.Models;
using Microsoft.Extensions.Options;

namespace Koronba.Core.Persistence.Stores;

/// <summary>
/// A flash file store that's disk-backed.
/// </summary>
public class DiskFlashFileStore : IFlashFileStore
{
    /// <summary>
    /// The path to the store.
    /// </summary>
    private readonly string _storePath;
    
    /// <summary>
    /// Creates a new disk-backed flash file store.
    /// </summary>
    /// <param name="config">The Koronba configuration.</param>
    public DiskFlashFileStore(IOptions<KoronbaCoreConfiguration> config)
    {
        _storePath = config.Value
            .FileStorePath;
    }
    
    /// <inheritdoc/>
    public Stream? GetStreamFor(Flash flash)
    {
        var path = Path.Combine(_storePath, $"{flash.Hash}.swf");
        
        return !File.Exists(path) ? 
            null : 
            new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
    }

    /// <inheritdoc/>
    public async Task<bool> StoreFile(Flash flash, Stream stream)
    {
        var path = Path.Combine(_storePath, $"{flash.Hash}.swf");
        var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        await stream.CopyToAsync(fs);
        
        return true;
    }
}
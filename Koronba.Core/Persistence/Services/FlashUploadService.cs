using System.Security.Cryptography;
using Hangfire;
using Koronba.Core.Jobs;
using Koronba.Core.Models;
using Koronba.Core.Models.Dtos;
using Koronba.Core.Persistence.Repositories;
using Koronba.Core.Persistence.Stores;

namespace Koronba.Core.Persistence.Services;

/// <summary>
/// The flash upload service.
/// </summary>
public class FlashUploadService(
    IFlashRepository repo,
    IFlashFileStore store) : IFlashUploadService
{
    /// <summary>
    /// The flash repository.
    /// </summary>
    private readonly IFlashRepository _repo = repo;

    /// <summary>
    /// The flash file store.
    /// </summary>
    private readonly IFlashFileStore _store = store;

    /// <inheritdoc/>
    public async Task<Flash?> Upload(FlashUploadDto uploadDto)
    {
        using var ms = new MemoryStream();
        await uploadDto.UploadStream.CopyToAsync(ms);
        ms.Seek(0, SeekOrigin.Begin);

        var hash = await GetHashFor(ms);
        var flash = await _repo.FindByFileHash(hash);
        if (flash is not null)
        {
            flash.AddFilename(uploadDto.Filename);
            flash.MarkAsSeenNow();
            await _repo.Update(flash);

            return flash;
        }

        flash = new Flash
        {
            Hash = hash,
            Metadata = new FlashMeta
            {
                FileSize = 0
            },
            Tags = [],
            KnownNames = [],
            CreatedAt = DateTime.Now
        };
        flash.AddFilename(uploadDto.Filename);
        flash.MarkAsSeenNow();

        ms.Seek(0, SeekOrigin.Begin);

        if (!await _store.StoreFile(flash, ms))
            return null;
        
        await _repo.AddEntry(flash);

        BackgroundJob.Enqueue<ThumbnailGenerationJob>(t => t.Generate(flash));

        return flash;
    }
    
    /// <summary>
    /// Gets the hash for a stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns>The hash code of that file.</returns>
    private static async Task<string> GetHashFor(Stream stream)
    {
        using var sha256 = SHA256.Create();
        var result = await sha256.ComputeHashAsync(stream);
            
        return string.Join(
            "", 
            result.Select(x => x.ToString("X2"))
            );
    }
}
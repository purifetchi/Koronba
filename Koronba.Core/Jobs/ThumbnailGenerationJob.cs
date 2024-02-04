using Koronba.Core.Models;
using Koronba.Core.Persistence.Stores;
using Koronba.External.Services.Thumbnails;

namespace Koronba.Core.Jobs;

/// <summary>
/// The thumbnail generation job.
/// </summary>
public class ThumbnailGenerationJob(
    IThumbnailGeneratorService thumbnailGenerator,
    IFlashFileStore store,
    IThumbnailStore thumbnailStore
    )
{
    /// <summary>
    /// The thumbnail generator.
    /// </summary>
    private readonly IThumbnailGeneratorService _thumbnailGenerator = thumbnailGenerator;

    /// <summary>
    /// The flash file store.
    /// </summary>
    private readonly IFlashFileStore _store = store;

    /// <summary>
    /// The thumbnail store.
    /// </summary>
    private readonly IThumbnailStore _thumbnailStore = thumbnailStore;
    
    /// <summary>
    /// Generates the thumbnail for a flash entry.
    /// </summary>
    /// <param name="flash">The entry.</param>
    public async Task Generate(Flash flash)
    {
        await using var readStream = _store.GetStreamFor(flash);
        if (readStream is null)
            return;

        var tempDir = Path.Combine(
            Path.GetTempPath(),
            Path.GetRandomFileName());

        var flashPath = Path.Combine(
            tempDir,
            $"{flash.Hash}.swf");

        Directory.CreateDirectory(tempDir);

        // Copy the flash temporarily to the temp dir to generate the thumbnail.
        await using (var fs = new FileStream(flashPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            await readStream.CopyToAsync(fs);

        var thumbPath = await _thumbnailGenerator.GenerateThumbnailFor(flashPath);
        if (string.IsNullOrEmpty(thumbPath))
            return;

        await using (var fs = new FileStream(thumbPath, FileMode.Open, FileAccess.Read, FileShare.None))
            await _thumbnailStore.StoreThumbnail(flash, fs);

        Directory.Delete(tempDir, true);
    }
}
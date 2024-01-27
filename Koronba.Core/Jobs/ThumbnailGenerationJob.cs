using Koronba.Core.Models;
using Koronba.Core.Persistence.Stores;
using Koronba.External.Services.Thumbnails;

namespace Koronba.Core.Jobs;

/// <summary>
/// The thumbnail generation job.
/// </summary>
public class ThumbnailGenerationJob(
    IThumbnailGeneratorService thumbnailGenerator,
    IFlashFileStore store
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
    /// Generates the thumbnail for a flash entry.
    /// </summary>
    /// <param name="flash">The entry.</param>
    public async void Generate(Flash flash)
    {
        using var readStream = _store.GetStreamFor(flash);
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
        using (var fs = new FileStream(flashPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            await readStream.CopyToAsync(fs);

        var thumbPath = await _thumbnailGenerator.GenerateThumbnailFor(flashPath);
        if (string.IsNullOrEmpty(thumbPath))
            return;

        Directory.Delete(tempDir, true);
    }
}
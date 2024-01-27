namespace Koronba.External.Services.Thumbnails;

/// <summary>
/// A generator using Ruffle to make thumbnails.
/// </summary>
public class RuffleThumbnailGeneratorService
    : IThumbnailGeneratorService
{
    /// <inheritdoc/>
    public Task<string> GenerateThumbnailFor(string path)
    {
        return Task.FromResult(string.Empty);
    }
}

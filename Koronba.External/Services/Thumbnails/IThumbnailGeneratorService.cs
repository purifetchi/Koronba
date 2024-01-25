namespace Koronba.External.Services.Thumbnails;

/// <summary>
/// The thumbnail generator service.
/// </summary>
public interface IThumbnailGeneratorService
{
    /// <summary>
    /// Creates a thumbnail for the given path.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The resulting thumbnail path.</returns>
    Task<string> GenerateThumbnailFor(string path);
}
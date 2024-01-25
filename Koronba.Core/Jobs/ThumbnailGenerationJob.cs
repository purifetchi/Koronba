using Koronba.Core.Models;
using Koronba.External.Services.Thumbnails;

namespace Koronba.Core.Jobs;

/// <summary>
/// The thumbnail generation job.
/// </summary>
public class ThumbnailGenerationJob(
    IThumbnailGeneratorService thumbnailGenerator
    )
{
    /// <summary>
    /// The thumbnail generator.
    /// </summary>
    private readonly IThumbnailGeneratorService _thumbnailGenerator = thumbnailGenerator;
    
    /// <summary>
    /// Generates the thumbnail for a flash entry.
    /// </summary>
    /// <param name="flash">The entry.</param>
    public void Generate(Flash flash)
    {
        
    }
}
using Koronba.Core.Models;

namespace Koronba.Core.Persistence.Stores;

/// <summary>
/// A store for thumbnail files.
/// </summary>
public interface IThumbnailStore
{
    /// <summary>
    /// Gets the thumbnail stream for a flash entry.
    /// </summary>
    /// <param name="flash">The flash entry.</param>
    /// <returns>The resulting stream, if the file exists.</returns>
    Stream? GetThumbnailStreamFor(Flash flash);

    /// <summary>
    /// Stores a flash entry thumbnail.
    /// </summary>
    /// <param name="flash">The flash entry.</param>
    /// <param name="stream">The stream.</param>
    /// <returns>Whether the storing was successful.</returns>
    Task<bool> StoreThumbnail(Flash flash, Stream stream);
}
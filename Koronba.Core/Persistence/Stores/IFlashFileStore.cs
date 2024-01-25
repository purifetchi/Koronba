using Koronba.Core.Models;

namespace Koronba.Core.Persistence.Stores;

/// <summary>
/// The store for flash files.
/// </summary>
public interface IFlashFileStore
{
    /// <summary>
    /// Gets the file stream for a flash entry.
    /// </summary>
    /// <param name="flash">The flash entry.</param>
    /// <returns>The resulting stream, if the file exists.</returns>
    Stream? GetStreamFor(Flash flash);

    /// <summary>
    /// Stores a flash entry.
    /// </summary>
    /// <param name="flash">The flash entry.</param>
    /// <param name="stream">The stream.</param>
    /// <returns>Whether the storing was successful.</returns>
    Task<bool> StoreFile(Flash flash, Stream stream);
}
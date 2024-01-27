using Koronba.Core.Models;

namespace Koronba.Core.Persistence.Repositories;

/// <summary>
/// An interface implemented by anything that wants to store flash file entries.
/// </summary>
public interface IFlashRepository
{
    /// <summary>
    /// Adds a new entry.
    /// </summary>
    /// <param name="flash">The entry to add.</param>
    /// <returns>The resulting entity.</returns>
    Task<Flash> AddEntry(Flash flash);

    /// <summary>
    /// Updates a flash entry.
    /// </summary>
    /// <param name="flash">The flash entry.</param>
    /// <returns>Whether the update has been successful.</returns>
    Task<bool> Update(Flash flash);

    /// <summary>
    /// Finds a flash entry by its id.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <returns>The entry, if one exists.</returns>
    Task<Flash?> FindById(int id);

    /// <summary>
    /// Finds a flash file by its file hash.
    /// </summary>
    /// <param name="hash">The file hash.</param>
    /// <returns>The entry, if one exists.</returns>
    Task<Flash?> FindByFileHash(string hash);

    /// <summary>
    /// Finds all entries containing a name.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The enumerable of the result set.</returns>
    Task<List<Flash>> FindAllContainingName(string name);

    /// <summary>
    /// Gets the last <paramref name="count"/> last seen flash entries.
    /// </summary>
    /// <param name="count">The amount of last seen entries to fetch.</param>
    /// <returns>The list containing the entries.</returns>
    Task<List<Flash>> GetLastSeen(int count);

    /// <summary>
    /// Gets the last <paramref name="count"/> newest flash entries.
    /// </summary>
    /// <param name="count">The amount of newest entries to fetch.</param>
    /// <returns>The list containing the entries.</returns>
    Task<List<Flash>> GetNewest(int count);
}
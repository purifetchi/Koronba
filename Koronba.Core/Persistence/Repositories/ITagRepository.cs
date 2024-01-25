using Koronba.Core.Models;

namespace Koronba.Core.Persistence.Repositories;

/// <summary>
/// The tags repository.
/// </summary>
public interface ITagRepository
{
    /// <summary>
    /// Creates a new tag.
    /// </summary>
    /// <param name="tag">The tag to create.</param>
    /// <returns>The resulting tag entity.</returns>
    Task<Tag> Create(Tag tag);

    /// <summary>
    /// Finds a tag by name.
    /// </summary>
    /// <param name="name">The name of the tag.</param>
    /// <returns>The tag, if one exists.</returns>
    Task<Tag?> FindByName(string name);
}
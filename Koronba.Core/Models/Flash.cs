namespace Koronba.Core.Models;

/// <summary>
/// A flash entry.
/// </summary>
public class Flash
{
    /// <summary>
    /// The ID of the flash entry.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// The hash of the file.
    /// </summary>
    public string Hash { get; set; }
    
    /// <summary>
    /// The flash file metadata.
    /// </summary>
    public FlashMeta Metadata { get; set; }
    
    /// <summary>
    /// The list of known names.
    /// </summary>
    public List<FlashName> KnownNames { get; set; }
    
    /// <summary>
    /// The tags this file has.
    /// </summary>
    public List<Tag> Tags { get; set; }
    
    /// <summary>
    /// The time this entry was created at.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// The time this entry was last uploaded.
    /// </summary>
    public DateTime LastSeenAt { get; set; }

    /// <summary>
    /// Adds a tag to this flash entry.
    /// </summary>
    /// <param name="tag">The tag.</param>
    public void AddTag(Tag tag)
    {
        if (!Tags.Contains(tag))
            Tags.Add(tag);
    }

    /// <summary>
    /// Removes a tag from this flash entry.
    /// </summary>
    /// <param name="tag">The tag.</param>
    public void RemoveTag(Tag tag)
    {
        Tags.Remove(tag);
    }
}
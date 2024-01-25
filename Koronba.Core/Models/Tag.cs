namespace Koronba.Core.Models;

/// <summary>
/// A tag for a flash upload.
/// </summary>
public class Tag
{
    /// <summary>
    /// The ID of the tag.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// The name of the tag.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// The list of flash entries that have this tag.
    /// </summary>
    public List<Flash> Flashes { get; set; }
}
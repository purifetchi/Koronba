namespace Koronba.Core.Models;

/// <summary>
/// The metadata for a flash file.
/// </summary>
public class FlashMeta
{
    /// <summary>
    /// The id of the metadata entry.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// The file size (in KiB).
    /// </summary>
    public int FileSize { get; set; }
}
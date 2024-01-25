namespace Koronba.Core.Models;

/// <summary>
/// An entry for a known filename for a flash file.
/// </summary>
public class FlashName
{
    /// <summary>
    /// The ID of the flash filename.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// The filename.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// The seen count.
    /// </summary>
    public int Seen { get; set; }
}
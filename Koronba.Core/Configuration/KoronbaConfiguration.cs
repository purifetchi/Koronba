namespace Koronba.Core.Configuration;

/// <summary>
/// The Koronba core configuration.
/// </summary>
public class KoronbaCoreConfiguration
{
    /// <summary>
    /// The connection string.
    /// </summary>
    public required string ConnectionString { get; init; }
    
    /// <summary>
    /// The path to the flash file store.
    /// </summary>
    public required string FileStorePath { get; init; }
}
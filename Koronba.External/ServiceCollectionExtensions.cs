using Koronba.External.Services.Thumbnails;
using Microsoft.Extensions.DependencyInjection;

namespace Koronba.External;

/// <summary>
/// Extensions for the service collection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Koronba external services.
    /// </summary>
    /// <param name="collection">The service collection.</param>
    public static IServiceCollection AddKoronbaExternal(this IServiceCollection collection)
    {
        collection.AddTransient<IThumbnailGeneratorService, RuffleThumbnailGeneratorService>();

        return collection;
    }
}
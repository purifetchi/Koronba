using Koronba.Core.Persistence.DatabaseContexts;
using Koronba.Core.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Koronba.Core;

/// <summary>
/// Extensions for the service collection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Koronba core.
    /// </summary>
    /// <param name="collection">The service collection.</param>
    public static IServiceCollection AddKoronbaCore(this IServiceCollection collection)
    {
        collection.AddDbContext<KoronbaDbContext>()
            .AddScoped<IFlashRepository, FlashRepository>()
            .AddScoped<ITagRepository, TagRepository>();
        
        return collection;
    }
}
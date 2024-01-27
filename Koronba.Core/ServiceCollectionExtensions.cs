using Koronba.Core.Persistence.DatabaseContexts;
using Koronba.Core.Persistence.Repositories;
using Koronba.Core.Persistence.Services;
using Koronba.Core.Persistence.Stores;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;

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
            .AddScoped<IFlashFileStore, DiskFlashFileStore>()
            .AddScoped<IFlashUploadService, FlashUploadService>()
            .AddScoped<IFlashRepository, FlashRepository>()
            .AddScoped<ITagRepository, TagRepository>();
        
        return collection;
    }
}
using Koronba.Core.Models;
using Koronba.Core.Models.Dtos;

namespace Koronba.Core.Persistence.Services;

/// <summary>
/// The service facilitating helping uploading flash content.
/// </summary>
public interface IFlashUploadService
{
    /// <summary>
    /// Uploads a flash file.
    /// </summary>
    /// <param name="uploadDto">The upload DTO.</param>
    /// <returns>The flash entry, if upload succeeded.</returns>
    Task<Flash?> Upload(FlashUploadDto uploadDto);
}
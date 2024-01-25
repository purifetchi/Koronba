namespace Koronba.Core.Models.Dtos;

/// <summary>
/// The flash upload DTO.
/// </summary>
/// <param name="Filename">The filename.</param>
/// <param name="UploadStream">The upload file stream.</param>
public record FlashUploadDto(string Filename, Stream UploadStream);
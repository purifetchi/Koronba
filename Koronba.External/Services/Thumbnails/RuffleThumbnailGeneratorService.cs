using System.Diagnostics;
using Koronba.External.Configuration;
using Microsoft.Extensions.Options;

namespace Koronba.External.Services.Thumbnails;

/// <summary>
/// A generator using Ruffle to make thumbnails.
/// </summary>
public class RuffleThumbnailGeneratorService(IOptions<KoronbaExternalConfiguration> opts)
    : IThumbnailGeneratorService
{
    /// <summary>
    /// The path to ruffle's exporter.
    /// </summary>
    private readonly string? _rufflePath = opts.Value.RuffleExporterPath;

    /// <inheritdoc/>
    public async Task<string> GenerateThumbnailFor(string path)
    {
        if (string.IsNullOrWhiteSpace(_rufflePath))
            return string.Empty;

        var process = new Process
        {
            StartInfo =
            {
                FileName = _rufflePath,
                Arguments = path
            }
        };

        process.Start();
        await process.WaitForExitAsync();

        if (process.ExitCode != 0)
            return string.Empty;

        return Path.Combine(
            Path.GetDirectoryName(_rufflePath)!, 
            Path.GetFileNameWithoutExtension(path) + ".png");
    }
}

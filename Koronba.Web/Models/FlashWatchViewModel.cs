using Koronba.Core.Models;

namespace Koronba.Web.Models;

/// <summary>
/// The model for the watch route.
/// </summary>
/// <param name="Flash">The flash entry.</param>
/// <param name="Filename">The filename used.</param>
public record FlashWatchViewModel(Flash Flash, string Filename);
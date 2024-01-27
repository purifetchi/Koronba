using Koronba.Core.Models;

namespace Koronba.Web.Models;

/// <summary>
/// The model for the index.
/// </summary>
/// <param name="LastSeen">The lastest seen flash entries.</param>
/// <param name="Newest">The nwest flash entries.</param>
public record IndexViewModel(IReadOnlyList<Flash> LastSeen, IReadOnlyList<Flash> Newest);
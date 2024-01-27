using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Koronba.Models;
using Koronba.Core.Persistence.Repositories;

namespace Koronba.Controllers;

/// <summary>
/// The controller for the root route.
/// </summary>
/// <param name="repo">The flash repository.</param>
public class HomeController(IFlashRepository repo)
    : Controller
{
    /// <summary>
    /// The amount of entries for index.
    /// </summary>
    private const int MAX_ENTRIES_FOR_INDEX = 5;

    /// <summary>
    /// The flash repository.
    /// </summary>
    private readonly IFlashRepository _repo = repo;

    /// <summary>
    /// The "/" route.
    /// </summary>
    public async Task<IActionResult> Index()
    {
        var newest = await _repo.GetNewest(MAX_ENTRIES_FOR_INDEX);
        var latest = await _repo.GetLastSeen(MAX_ENTRIES_FOR_INDEX);
        return View(new IndexViewModel(latest, newest));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
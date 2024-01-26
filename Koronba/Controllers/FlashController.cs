using Koronba.Core.Persistence.Repositories;
using Koronba.Core.Persistence.Stores;
using Koronba.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koronba.Controllers;

/// <summary>
/// The controller for the "/Flash" route.
/// </summary>
[Route("/flash/{id:int}")]
public class FlashController(
    IFlashRepository repo,
    IFlashFileStore store) : Controller
{
    /// <summary>
    /// The flash entry repository.
    /// </summary>
    private readonly IFlashRepository _repo = repo;
    
    /// <summary>
    /// The flash file store.
    /// </summary>
    private readonly IFlashFileStore _store = store;

    /// <summary>
    /// Displays the information page for the flash file.
    /// </summary>
    /// <param name="id">The id of the flash file.</param>
    public async Task<IActionResult> Index([FromRoute] int id)
    {
        var flash = await _repo.FindById(id);
        if (flash is null)
            return NotFound("doesnt exist");

        return View(new FlashIndexViewModel(flash));
    }

    /// <summary>
    /// Displays the watch page for this flash file.
    /// </summary>
    /// <param name="id">The id of the flash file.</param>
    [Route("watch")]
    public async Task<IActionResult> Watch([FromRoute] int id)
    {
        var flash = await _repo.FindById(id);
        if (flash is null)
            return NotFound("doesnt exist");

        return View(new FlashIndexViewModel(flash));
    }

    /// <summary>
    /// Gets the specified flash file.
    /// </summary>
    /// <param name="id">The id of the flash file.</param>
    /// <param name="filename">The filename.</param>
    [Route("get")]
    public async Task<IActionResult> Get([FromRoute] int id,
        [FromQuery] string? filename)
    {
        var flash = await _repo.FindById(id);
        if (flash is null)
            return NotFound();

        var stream = _store.GetStreamFor(flash);
        if (stream is null)
            return NotFound();

        const string contentType = "application/x-shockwave-flash";
        return File(
            stream, 
            contentType, 
            filename ?? $"{id}.swf");
    }
}
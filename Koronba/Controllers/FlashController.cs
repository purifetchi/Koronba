using Koronba.Core.Persistence.Repositories;
using Koronba.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koronba.Controllers;

/// <summary>
/// The controller for the "/Flash" route.
/// </summary>
[Route("/flash/{id:int}")]
public class FlashController(
    IFlashRepository repo) : Controller
{
    /// <summary>
    /// The flash entry repository.
    /// </summary>
    private readonly IFlashRepository _repo = repo;

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
    public IActionResult Watch([FromRoute] int id)
    {
        return Ok("id-id: " + id);
    }
}
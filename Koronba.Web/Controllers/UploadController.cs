using Koronba.Core.Persistence.Services;
using Microsoft.AspNetCore.Mvc;

namespace Koronba.Web.Controllers;

/// <summary>
/// The controller responsible for handling file upload.
/// </summary>
[Route("/upload")]
public class UploadController(
    IFlashUploadService uploadService) : Controller
{
    /// <summary>
    /// The flash upload service.
    /// </summary>
    private readonly IFlashUploadService _flashUploadService = uploadService;
    
    /// <summary>
    /// The index for the upload page.
    /// </summary>
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// The POST upload method.
    /// </summary>
    /// <param name="file">The file to be uploaded.</param>
    [HttpPost]
    [Route("/upload")]
    public async Task<IActionResult> Upload([FromForm] IFormFile file)
    {
        var result = await _flashUploadService.Upload(new(file.FileName, file.OpenReadStream()));
        if (result is null)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return Accepted();
    }
}

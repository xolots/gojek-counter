using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Tesseract;
namespace gojekCounter.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    [HttpGet(Name = "Index")]
    public IActionResult testing()
    {
        return Ok($"Copyright By Hardian Eka Cahyadi");
    }

    [HttpPost(Name = "Index")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        string[] AllowedExtension = { ".pdf" };
        string fileExtension = Path.GetExtension(file.FileName).ToLower();
        if (file.Length == 0 || file == null || !AllowedExtension.Contains(fileExtension))
        {
            return NotFound(new
            {
                reason = "Tidak ditemukan atau format file tidak valid",
                fileLength = file.Length,
                extension = fileExtension,
                allowedExtension = AllowedExtension
            });
        }
        ;

        return Ok(new
        {
            file.FileName,
            file.ContentType,
        });
    }
}
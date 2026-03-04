using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Mvc;  
using System.IO;  
using System.Threading.Tasks;  
using ImageMagick;  

namespace TheLawrenceHousePsychologicalServices.Controllers  
{  
    [Route("api/[controller]")]  
    [ApiController]  
    public class ShowController : ControllerBase  
    {  
        [HttpPost("upload")]  
        public async Task<IActionResult> UploadPoster(IFormFile file)  
        {  
            if (file == null || file.Length == 0)  
                return BadRequest("No file uploaded.");  

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/posters", file.FileName);  
            using (var stream = new FileStream(filePath, FileMode.Create))  
            {  
                await file.CopyToAsync(stream);  
            }  

            // Optimize the image  
            using (var image = new MagickImage(filePath))  
            {  
                image.Resize(800, 800);  
                image.Write(filePath);  
            }  

            return Ok(new { filePath });  
        }  

        [HttpDelete("delete")]  
        public IActionResult DeletePoster(string fileName)  
        {  
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/posters", fileName);  
            if (!System.IO.File.Exists(filePath))  
                return NotFound();  

            System.IO.File.Delete(filePath);  
            return NoContent();  
        }  
    }  
}  

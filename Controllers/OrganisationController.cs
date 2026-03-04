using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace TheLawrenceHousePsychologicalServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganisationController : ControllerBase
    {
        private const string LogoPath = "wwwroot/logos/";

        [HttpPost("upload-logo/{organisationId}")]
        public async Task<IActionResult> UploadLogo(int organisationId, IFormFile logo)
        {
            if (logo == null || logo.Length == 0)
                return BadRequest("No logo file uploaded.");

            // Image optimization logic can be added here
            var filePath = Path.Combine(LogoPath, organisationId + Path.GetExtension(logo.FileName));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await logo.CopyToAsync(stream);
            }

            return Ok(new { message = "Logo uploaded successfully." });
        }

        [HttpDelete("delete-logo/{organisationId}")]
        public IActionResult DeleteLogo(int organisationId)
        {
            var filePath = Path.Combine(LogoPath, organisationId + ".jpg"); // assuming jpg for simplicity

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                return Ok(new { message = "Logo deleted successfully." });
            }

            return NotFound(new { message = "Logo not found." });
        }
    }
}
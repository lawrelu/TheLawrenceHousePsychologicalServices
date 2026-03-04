using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShow(int id)
        {
            try
            {
                var show = await _showService.GetShowAsync(id);
                if (show == null)
                    return NotFound("Show not found");
                return Ok(show);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateShow([FromBody] Show show)
        {
            try
            {
                var createdShow = await _showService.CreateShowAsync(show);
                return CreatedAtAction(nameof(GetShow), new { id = createdShow.Id }, createdShow);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id}"])
        public async Task<IActionResult> UpdateShow(int id, [FromBody] Show show)
        {
            try
            {
                show.Id = id;
                var updatedShow = await _showService.UpdateShowAsync(show);
                return Ok(updatedShow);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(int id)
        {
            try
            {
                var success = await _showService.DeleteShowAsync(id);
                if (!success)
                    return NotFound("Show not found");
                return Ok(new { message = "Show deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("organisation/{organisationId}")]
        public async Task<IActionResult> GetShowsByOrganisation(int organisationId)
        {
            try
            {
                var shows = await _showService.GetShowsByOrganisationAsync(organisationId);
                return Ok(shows);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
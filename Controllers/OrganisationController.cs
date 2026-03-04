using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]"])
    public class OrganisationController : ControllerBase
    {
        private readonly IOrganisationService _organisationService;

        public OrganisationController(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganisation(int id)
        {
            try
            {
                var organisation = await _organisationService.GetOrganisationAsync(id);
                if (organisation == null)
                    return NotFound("Organisation not found");

                return Ok(organisation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganisation([FromBody] Organisation organisation)
        {
            try
            {
                var createdOrganisation = await _organisationService.CreateOrganisationAsync(organisation);
                return CreatedAtAction(nameof(GetOrganisation), new { id = createdOrganisation.Id }, createdOrganisation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganisation(int id, [FromBody] Organisation organisation)
        {
            try
            {
                organisation.Id = id;
                var updatedOrganisation = await _organisationService.UpdateOrganisationAsync(organisation);
                return Ok(updatedOrganisation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganisation(int id)
        {
            try
            {
                var success = await _organisationService.DeleteOrganisationAsync(id);
                if (!success)
                    return NotFound("Organisation not found");

                return Ok(new { message = "Organisation deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrganisations()
        {
            try
            {
                var organisations = await _organisationService.GetAllOrganisationsAsync();
                return Ok(organisations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
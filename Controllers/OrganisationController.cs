using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TheLawrenceHousePsychologicalServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganisationController : ControllerBase
    {
        // GET: api/organisation
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllOrganisations()
        {
            // Logic to get all organisations
            return Ok(new string[] { "Organisation1", "Organisation2" });
        }

        // GET: api/organisation/{id}
        [HttpGet("{id}")]
        public ActionResult<string> GetOrganisation(int id)
        {
            // Logic to get a specific organisation by id
            return Ok("Organisation" + id);
        }

        // POST: api/organisation
        [HttpPost]
        public ActionResult CreateOrganisation([FromBody] string organisation)
        {
            // Logic to create an organisation
            return CreatedAtAction(nameof(GetOrganisation), new { id = 1 }, organisation);
        }

        // PUT: api/organisation/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOrganisation(int id, [FromBody] string organisation)
        {
            // Logic to update an organisation
            return NoContent();
        }

        // DELETE: api/organisation/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrganisation(int id)
        {
            // Logic to delete an organisation
            return NoContent();
        }
    }
}
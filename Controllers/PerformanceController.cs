using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
namespace Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PerformanceController : ControllerBase {
        private readonly IPerformanceService _performanceService;

        public PerformanceController(IPerformanceService performanceService) {
            _performanceService = performanceService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerformance(int id) {
            try {
                var performance = await _performanceService.GetPerformanceAsync(id);
                if (performance == null)
                    return NotFound("Performance not found");
                return Ok(performance);
            } catch (Exception ex) {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerformance([FromBody] Performance performance) {
            try {
                var createdPerformance = await _performanceService.CreatePerformanceAsync(performance);
                return CreatedAtAction(nameof(GetPerformance), new { id = createdPerformance.Id }, createdPerformance);
            } catch (Exception ex) {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerformance(int id, [FromBody] Performance performance) {
            try {
                performance.Id = id;
                var updatedPerformance = await _performanceService.UpdatePerformanceAsync(performance);
                return Ok(updatedPerformance);
            } catch (Exception ex) {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformance(int id) {
            try {
                var success = await _performanceService.DeletePerformanceAsync(id);
                if (!success)
                    return NotFound("Performance not found");
                return Ok(new { message = "Performance deleted successfully" });
            } catch (Exception ex) {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("show/{showId}")]
        public async Task<IActionResult> GetPerformancesByShow(int showId) {
            try {
                var performances = await _performanceService.GetPerformancesByShowAsync(showId);
                return Ok(performances);
            } catch (Exception ex) {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{performanceId}/attendance")]
        public async Task<IActionResult> GetPerformanceAttendance(int performanceId) {
            try {
                var attendance = await _performanceService.GetPerformanceAttendanceAsync(performanceId);
                return Ok(attendance);
            } catch (Exception ex) {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TheLawrenceHousePsychologicalServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        // This will hold performance data
        private static List<PerformanceRecord> _performanceRecords = new List<PerformanceRecord>();

        // GET: api/performance
        [HttpGet]
        public ActionResult<IEnumerable<PerformanceRecord>> GetPerformanceRecords()
        {
            return Ok(_performanceRecords);
        }

        // POST: api/performance
        [HttpPost]
        public ActionResult<PerformanceRecord> CreatePerformanceRecord([FromBody] PerformanceRecord record)
        {
            _performanceRecords.Add(record);
            return CreatedAtAction(nameof(GetPerformanceRecords), new { id = record.Id }, record);
        }

        // Additional methods for tracking attendance can be added here
    }

    public class PerformanceRecord
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string PerformanceData { get; set; }
        public DateTime Date { get; set; }
    }
}
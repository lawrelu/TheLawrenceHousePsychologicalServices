using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly INFCReaderService _nfcReaderService;
        private readonly IMemberService _memberService;

        public AttendanceController(IAttendanceService attendanceService, INFCReaderService nfcReaderService, IMemberService memberService)
        {
            _attendanceService = attendanceService;
            _nfcReaderService = nfcReaderService;
            _memberService = memberService;
        }

        [HttpPost("check-in/{performanceId}")]
        public async Task<IActionResult> CheckInWithNFC(int performanceId)
        {
            try
            {
                var nfcTagId = await _nfcReaderService.ReadNFCTagAsync();
                if (string.IsNullOrEmpty(nfcTagId)) return BadRequest("Failed to read NFC tag");

                var member = await _memberService.GetMemberByNFCTagAsync(nfcTagId);
                if (member == null) return NotFound("Member not found");

                var success = await _attendanceService.CheckInMemberAsync(member.Id, performanceId);
                if (!success) return BadRequest("Check-in failed");

                return Ok(new { message = "Check-in successful", memberId = member.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost("check-out/{memberId}/{performanceId}")]
        public async Task<IActionResult> CheckOut(int memberId, int performanceId)
        {
            try
            {
                var success = await _attendanceService.CheckOutMemberAsync(memberId, performanceId);
                if (!success) return BadRequest("Check-out failed");

                return Ok(new { message = "Check-out successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{memberId}/{performanceId}")]
        public async Task<IActionResult> GetAttendanceLog(int memberId, int performanceId)
        {
            try
            {
                var log = await _attendanceService.GetAttendanceLogAsync(memberId, performanceId);
                if (log == null) return NotFound("Attendance log not found");

                return Ok(log);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("by-nfc/{nfcTagId}")]
        public async Task<IActionResult> GetMemberByNFC(string nfcTagId)
        {
            try
            {
                var member = await _memberService.GetMemberByNFCTagAsync(nfcTagId);
                if (member == null) return NotFound("Member not found");
                return Ok(member);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] Member member)
        {
            try
            {
                var createdMember = await _memberService.CreateMemberAsync(member);
                return CreatedAtAction(nameof(CreateMember), new { id = createdMember.Id }, createdMember);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] Member member)
        {
            try
            {
                member.Id = id;
                var updatedMember = await _memberService.UpdateMemberAsync(member);
                return Ok(updatedMember);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                var success = await _memberService.DeleteMemberAsync(id);
                if (!success) return NotFound("Member not found");
                return Ok(new { message = "Member deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("organisation/{organisationId}")]
        public async Task<IActionResult> GetMembersByOrganisation(int organisationId)
        {
            try
            {
                var members = await _memberService.GetMembersByOrganisationAsync(organisationId);
                return Ok(members);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
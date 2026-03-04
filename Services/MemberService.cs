using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Services {
    public interface IMemberService {
        Task<Member> GetMemberByNFCTagAsync(string nfcTagId);
        Task<Member> CreateMemberAsync(Member member);
        Task<Member> UpdateMemberAsync(Member member);
        Task<bool> DeleteMemberAsync(int memberId);
        Task<List<Member>> GetMembersByOrganisationAsync(int organisationId);
    }

    public class MemberService : IMemberService {
        private readonly StagedoorDbContext _context;

        public MemberService(StagedoorDbContext context) {
            _context = context;
        }

        public async Task<Member> GetMemberByNFCTagAsync(string nfcTagId) {
            return await _context.Members
                .FirstOrDefaultAsync(m => m.NFCTagId == nfcTagId && m.IsActive);
        }

        public async Task<Member> CreateMemberAsync(Member member) {
            try {
                member.CreatedAt = DateTime.UtcNow;
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                return member;
            } catch (Exception ex) {
                throw new Exception($"Error creating member: {ex.Message}");
            }
        }

        public async Task<Member> UpdateMemberAsync(Member member) {
            try {
                _context.Members.Update(member);
                await _context.SaveChangesAsync();
                return member;
            } catch (Exception ex) {
                throw new Exception($"Error updating member: {ex.Message}");
            }
        }

        public async Task<bool> DeleteMemberAsync(int memberId) {
            try {
                var member = await _context.Members.FindAsync(memberId);
                if (member == null) return false;
                member.IsActive = false;
                _context.Members.Update(member);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception ex) {
                throw new Exception($"Error deleting member: {ex.Message}");
            }
        }

        public async Task<List<Member>> GetMembersByOrganisationAsync(int organisationId) {
            return await _context.Members
                .Where(m => m.OrganisationId == organisationId && m.IsActive)
                .ToListAsync();
        }
    }
}
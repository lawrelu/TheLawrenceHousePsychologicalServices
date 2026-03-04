using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Services {
    public interface IOrganisationService {
        Task<Organisation> GetOrganisationAsync(int organisationId);
        Task<Organisation> CreateOrganisationAsync(Organisation organisation);
        Task<Organisation> UpdateOrganisationAsync(Organisation organisation);
        Task<bool> DeleteOrganisationAsync(int organisationId);
        Task<List<Organisation>> GetAllOrganisationsAsync();
    }

    public class OrganisationService : IOrganisationService {
        private readonly StagedoorDbContext _context;

        public OrganisationService(StagedoorDbContext context) {
            _context = context;
        }

        public async Task<Organisation> GetOrganisationAsync(int organisationId) {
            return await _context.Organisations
                .Include(o => o.Shows)
                .FirstOrDefaultAsync(o => o.Id == organisationId);
        }

        public async Task<Organisation> CreateOrganisationAsync(Organisation organisation) {
            try {
                organisation.CreatedAt = DateTime.UtcNow;
                _context.Organisations.Add(organisation);
                await _context.SaveChangesAsync();
                return organisation;
            } catch (Exception ex) {
                throw new Exception($"Error creating organisation: {ex.Message}");
            }
        }

        public async Task<Organisation> UpdateOrganisationAsync(Organisation organisation) {
            try {
                _context.Organisations.Update(organisation);
                await _context.SaveChangesAsync();
                return organisation;
            } catch (Exception ex) {
                throw new Exception($"Error updating organisation: {ex.Message}");
            }
        }

        public async Task<bool> DeleteOrganisationAsync(int organisationId) {
            try {
                var organisation = await _context.Organisations.FindAsync(organisationId);
                if (organisation == null) return false;
                _context.Organisations.Remove(organisation);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception ex) {
                throw new Exception($"Error deleting organisation: {ex.Message}");
            }
        }

        public async Task<List<Organisation>> GetAllOrganisationsAsync() {
            return await _context.Organisations
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }
    }
}
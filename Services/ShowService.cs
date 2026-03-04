using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Services {
    public interface IShowService {
        Task<Show> GetShowAsync(int showId);
        Task<Show> CreateShowAsync(Show show);
        Task<Show> UpdateShowAsync(Show show);
        Task<bool> DeleteShowAsync(int showId);
        Task<List<Show>> GetShowsByOrganisationAsync(int organisationId);
    }

    public class ShowService : IShowService {
        private readonly StagedoorDbContext _context;

        public ShowService(StagedoorDbContext context) {
            _context = context;
        }

        public async Task<Show> GetShowAsync(int showId) {
            return await _context.Shows
                .Include(s => s.Organisation)
                .Include(s => s.Performances)
                .FirstOrDefaultAsync(s => s.Id == showId);
        }

        public async Task<Show> CreateShowAsync(Show show) {
            try {
                show.CreatedAt = DateTime.UtcNow;
                _context.Shows.Add(show);
                await _context.SaveChangesAsync();
                return show;
            } catch (Exception ex) {
                throw new Exception($"Error creating show: {ex.Message}");
            }
        }

        public async Task<Show> UpdateShowAsync(Show show) {
            try {
                _context.Shows.Update(show);
                await _context.SaveChangesAsync();
                return show;
            } catch (Exception ex) {
                throw new Exception($"Error updating show: {ex.Message}");
            }
        }

        public async Task<bool> DeleteShowAsync(int showId) {
            try {
                var show = await _context.Shows.FindAsync(showId);
                if (show == null) return false;
                _context.Shows.Remove(show);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception ex) {
                throw new Exception($"Error deleting show: {ex.Message}");
            }
        }

        public async Task<List<Show>> GetShowsByOrganisationAsync(int organisationId) {
            return await _context.Shows
                .Where(s => s.OrganisationId == organisationId)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }
    }
}
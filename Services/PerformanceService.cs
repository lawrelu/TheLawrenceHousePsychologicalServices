using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Services {
    public interface IPerformanceService {
        Task<Performance> GetPerformanceAsync(int performanceId);
        Task<Performance> CreatePerformanceAsync(Performance performance);
        Task<Performance> UpdatePerformanceAsync(Performance performance);
        Task<bool> DeletePerformanceAsync(int performanceId);
        Task<List<Performance>> GetPerformancesByShowAsync(int showId);
        Task<List<AttendanceLog>> GetPerformanceAttendanceAsync(int performanceId);
    }

    public class PerformanceService : IPerformanceService {
        private readonly StagedoorDbContext _context;

        public PerformanceService(StagedoorDbContext context) {
            _context = context;
        }

        public async Task<Performance> GetPerformanceAsync(int performanceId) {
            return await _context.Performances
                .Include(p => p.Show)
                .Include(p => p.AttendanceLogs)
                .FirstOrDefaultAsync(p => p.Id == performanceId);
        }

        public async Task<Performance> CreatePerformanceAsync(Performance performance) {
            try {
                performance.CreatedAt = DateTime.UtcNow;
                _context.Performances.Add(performance);
                await _context.SaveChangesAsync();
                return performance;
            } catch (Exception ex) {
                throw new Exception($"Error creating performance: {ex.Message}");
            }
        }

        public async Task<Performance> UpdatePerformanceAsync(Performance performance) {
            try {
                _context.Performances.Update(performance);
                await _context.SaveChangesAsync();
                return performance;
            } catch (Exception ex) {
                throw new Exception($"Error updating performance: {ex.Message}");
            }
        }

        public async Task<bool> DeletePerformanceAsync(int performanceId) {
            try {
                var performance = await _context.Performances.FindAsync(performanceId);
                if (performance == null) return false;
                _context.Performances.Remove(performance);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception ex) {
                throw new Exception($"Error deleting performance: {ex.Message}");
            }
        }

        public async Task<List<Performance>> GetPerformancesByShowAsync(int showId) {
            return await _context.Performances
                .Where(p => p.ShowId == showId && p.IsActive)
                .OrderByDescending(p => p.PerformanceDate)
                .ToListAsync();
        }

        public async Task<List<AttendanceLog>> GetPerformanceAttendanceAsync(int performanceId) {
            return await _context.AttendanceLogs
                .Where(al => al.PerformanceId == performanceId)
                .Include(al => al.Member)
                .ToListAsync();
        }
    }
}
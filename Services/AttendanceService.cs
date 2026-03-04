using System;
using System.Threading.Tasks;
using Data;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Services {
    public interface IAttendanceService {
        Task<bool> CheckInMemberAsync(int memberId, int performanceId);
        Task<bool> CheckOutMemberAsync(int memberId, int performanceId);
        Task<AttendanceLog> GetAttendanceLogAsync(int memberId, int performanceId);
    }

    public class AttendanceService : IAttendanceService {
        private readonly StagedoorDbContext _context;

        public AttendanceService(StagedoorDbContext context) {
            _context = context;
        }

        public async Task<bool> CheckInMemberAsync(int memberId, int performanceId) {
            try {
                var member = await _context.Members.FindAsync(memberId);
                if (member == null) return false;

                var performance = await _context.Performances.FindAsync(performanceId);
                if (performance == null) return false;

                var existingLog = await _context.AttendanceLogs
                    .FirstOrDefaultAsync(al => al.MemberId == memberId && al.PerformanceId == performanceId);
                if (existingLog != null) {
                    return false;
                }

                var attendanceLog = new AttendanceLog {
                    MemberId = memberId,
                    PerformanceId = performanceId,
                    CheckInTime = DateTime.UtcNow,
                    IsPresent = true
                };

                _context.AttendanceLogs.Add(attendanceLog);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception ex) {
                throw new Exception($"Error checking in member: {ex.Message}");
            }
        }

        public async Task<bool> CheckOutMemberAsync(int memberId, int performanceId) {
            try {
                var attendanceLog = await _context.AttendanceLogs
                    .FirstOrDefaultAsync(al => al.MemberId == memberId && al.PerformanceId == performanceId);
                if (attendanceLog == null) return false;
                attendanceLog.CheckOutTime = DateTime.UtcNow;

                _context.AttendanceLogs.Update(attendanceLog);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception ex) {
                throw new Exception($"Error checking out member: {ex.Message}");
            }
        }

        public async Task<AttendanceLog> GetAttendanceLogAsync(int memberId, int performanceId) {
            return await _context.AttendanceLogs
                .FirstOrDefaultAsync(al => al.MemberId == memberId && al.PerformanceId == performanceId);
        }
    }
}
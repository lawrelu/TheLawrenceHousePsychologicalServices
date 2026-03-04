using System;
using System.Collections.Generic;

namespace Models
{
    public class Performance
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public DateTime PerformanceDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Member> Members { get; set; } = new List<Member>();
        public ICollection<AttendanceLog> AttendanceLogs { get; set; } = new List<AttendanceLog>();
    }
}
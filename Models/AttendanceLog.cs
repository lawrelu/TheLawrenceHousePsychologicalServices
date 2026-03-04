using System;

namespace Models {
    public class AttendanceLog {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int PerformanceId { get; set; }
        public Performance Performance { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public bool IsPresent { get; set; } = true;
        public string Notes { get; set; }
    }
}
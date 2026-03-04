using System;
using System.Collections.Generic;

namespace Models
{
    public class Member
    {
        public int Id { get; set; }
        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PhotoData { get; set; }
        public string NFCTagId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<AttendanceLog> AttendanceLogs { get; set; } = new List<AttendanceLog>();
        public ICollection<Performance> Performances { get; set; } = new List<Performance>();
    }
}
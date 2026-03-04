using System;
using System.Collections.Generic;

namespace Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Show> Shows { get; set; } = new List<Show>();
        public List<Member> Members { get; set; } = new List<Member>();
    }

    public class Show
    {
        public int Id { get; set; }
        public int OrganisationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Organisation Organisation { get; set; }
        public List<Performance> Performances { get; set; } = new List<Performance>();
    }

    public class Performance
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public DateTime PerformanceDate { get; set; }
        public string VenueName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Show Show { get; set; }
        public List<AttendanceLog> AttendanceLogs { get; set; } = new List<AttendanceLog>();
    }

    public class Member
    {
        public int Id { get; set; }
        public int OrganisationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NFCTagId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Organisation Organisation { get; set; }
        public List<AttendanceLog> AttendanceLogs { get; set; } = new List<AttendanceLog>();
    }

    public class AttendanceLog
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int PerformanceId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public bool IsPresent { get; set; }
        public Member Member { get; set; }
        public Performance Performance { get; set; }
    }
}
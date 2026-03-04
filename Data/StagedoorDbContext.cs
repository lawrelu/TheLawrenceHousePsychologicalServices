using Microsoft.EntityFrameworkCore;
using Models;
namespace Data {
    public class StagedoorDbContext : DbContext {
        public StagedoorDbContext(DbContextOptions<StagedoorDbContext> options) : base(options) {}

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<AttendanceLog> AttendanceLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Organisation>().HasKey(o => o.Id);
            modelBuilder.Entity<Organisation>().Property(o => o.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Show>().HasKey(s => s.Id);
            modelBuilder.Entity<Show>().HasOne(s => s.Organisation).WithMany(o => o.Shows).HasForeignKey(s => s.OrganisationId);
            modelBuilder.Entity<Show>().Property(s => s.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Performance>().HasKey(p => p.Id);
            modelBuilder.Entity<Performance>().HasOne(p => p.Show).WithMany(s => s.Performances).HasForeignKey(p => p.ShowId);
            modelBuilder.Entity<Member>().HasKey(m => m.Id);
            modelBuilder.Entity<Member>().HasOne(m => m.Organisation).WithMany(o => o.Members).HasForeignKey(m => m.OrganisationId);
            modelBuilder.Entity<Member>().Property(m => m.NFCTagId).IsRequired(false);
            modelBuilder.Entity<AttendanceLog>().HasKey(al => al.Id);
            modelBuilder.Entity<AttendanceLog>().HasOne(al => al.Member).WithMany(m => m.AttendanceLogs).HasForeignKey(al => al.MemberId);
            modelBuilder.Entity<AttendanceLog>().HasOne(al => al.Performance).WithMany(p => p.AttendanceLogs).HasForeignKey(al => al.PerformanceId);
        }
    }
}
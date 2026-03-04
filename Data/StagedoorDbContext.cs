using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class StagedoorDbContext : DbContext
    {
        public StagedoorDbContext(DbContextOptions<StagedoorDbContext> options) : base(options)
        {
        }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<AttendanceLog> AttendanceLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Show>()
                .HasOne(s => s.Organisation)
                .WithMany(o => o.Shows)
                .HasForeignKey(s => s.OrganisationId);

            modelBuilder.Entity<Performance>()
                .HasOne(p => p.Show)
                .WithMany(s => s.Performances)
                .HasForeignKey(p => p.ShowId);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.Organisation)
                .WithMany()
                .HasForeignKey(m => m.OrganisationId);

            modelBuilder.Entity<AttendanceLog>()
                .HasOne(al => al.Member)
                .WithMany(m => m.AttendanceLogs)
                .HasForeignKey(al => al.MemberId);

            modelBuilder.Entity<AttendanceLog>()
                .HasOne(al => al.Performance)
                .WithMany(p => p.AttendanceLogs)
                .HasForeignKey(al => al.PerformanceId);
        }
    }
}
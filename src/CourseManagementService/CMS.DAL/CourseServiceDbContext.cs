using CMS.DAL.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CMS.DAL
{
    public class CourseServiceDbContext : DbContext
    {
        public DbSet<CourseInformation> CourseInformations { get; set; }
        public DbSet<StudentCourseJunction> StudentCourseJunctions { get; set; }
        public DbSet<StudentCourseScore> StudentCourseScores { get; set; }

        public CourseServiceDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourseJunction>()
                .HasIndex(s => new { s.FKStudentID, s.FKCourseID })
                .IsUnique();

            builder.Entity<StudentCourseScore>()
              .HasIndex(s => new { s.FKStudentID, s.FKCourseID, s.Deleted })
              .IsUnique();
        }
    }
}

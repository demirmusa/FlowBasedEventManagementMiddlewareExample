using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DAL.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.DAL
{
    public class SMSDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<StudentInformation> StudentInformations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        public SMSDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentInformation>()
                .HasIndex(s => s.StudentNumber)
                .IsUnique();
        }
    }
}

using EntityFrameworkCoreTask.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreTask.Context
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .Property(e => e.StudentName)
            .HasMaxLength(100);

            modelBuilder.Entity<Subject>()
                .Property(e => e.SubjectName)
                .HasMaxLength(100);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(e => e.Student)
                .WithMany(e => e.StudentSubjects)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(e => e.Subject)
                .WithMany(e => e.StudentSubjects)
                .HasForeignKey(e => e.SubjectId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=UniversityDb;Integrated security=true;MultipleActiveResultSets=true");
        }
    }
}

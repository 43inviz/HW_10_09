using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10_09
{
    internal class ApplicationContext:DbContext
    {

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R3LQDV9;Database = TestDB1;Trusted_Connection =True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>().HasMany(i=>i.Courses).WithOne(c=>c.Instructor).HasForeignKey(c=>c.InstructorId);

            modelBuilder.Entity<Course>().HasMany(c=>c.Enrollments).WithOne(e=>e.Course).HasForeignKey(e=>e.CourseId);

            modelBuilder.Entity<Enrollment>().HasOne(e=>e.Student).WithMany(s=>s.Enrollments).HasForeignKey(e=>e.StudentId);
        }
    }
}

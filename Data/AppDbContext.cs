using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using School_WepApi.Models;

namespace School_WepApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions options) : base(options) { }


         

        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }

        public DbSet<Enrollment> enrollments { get; set; }

        public DbSet<StudentProfile> studentProfiles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
               .HasOne(s => s.StudentProfile)
               .WithOne(s => s.student)
               .HasForeignKey<StudentProfile>(p => p.studentId);

            modelBuilder.Entity<Course>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.TeacherId);


            modelBuilder.Entity<Enrollment>()
                .HasOne(x => x.Student)
                .WithMany(x => x.enrollments)
                .HasForeignKey(x => x.StudentId);


            modelBuilder.Entity<Enrollment>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.CourseId);


            modelBuilder.Entity<Enrollment>()
                  .HasIndex(e => new { e.StudentId, e.CourseId })
                  .IsUnique();




            modelBuilder.Entity<Teacher>()
            .HasData(
            new Teacher { Id = 1, FullName = "Ahmed Samir", Email = "ahmed.samir@school.com", Phone = "01044444444", HireDate = new DateTime(2020, 9, 1) },
            new Teacher { Id = 2, FullName = "Nour Adel", Email = "nour.adel@school.com", Phone = "01055555555", HireDate = new DateTime(2021, 2, 15) },
            new Teacher { Id = 3, FullName = "Hany Mostafa", Email = "hany.mostafa@school.com", Phone = "01066666666", HireDate = new DateTime(2019, 8, 20) }
            );

            
            modelBuilder.Entity<Student>()
                .HasData(
                new Student { Id = 1, FullName = "Ali Hassan", Email = "ali.hassan@school.com", Phone = "01011111111", BirthDate = new DateTime(2010, 5, 12), Gender = "Male" },
                new Student { Id = 2, FullName = "Mariam Ahmed", Email = "mariam.ahmed@school.com", Phone = "01022222222", BirthDate = new DateTime(2010, 8, 20), Gender = "Female" },
                new Student { Id = 3, FullName = "Omar Khaled", Email = "omar.khaled@school.com", Phone = "01033333333", BirthDate = new DateTime(2009, 11, 5), Gender = "Male" }
            );

           
            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile { Id = 1, Address = "Nasr City, Cairo", ParentPhone = "01111111111", EmergencyContact = "01211111111", studentId = 1 },
                new StudentProfile { Id = 2, Address = "Heliopolis, Cairo", ParentPhone = "01122222222", EmergencyContact = "01222222222", studentId = 2 },
                new StudentProfile { Id = 3, Address = "Maadi, Cairo", ParentPhone = "01133333333", EmergencyContact = "01233333333", studentId = 3 }
            );

            
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Programming Fundamentals", CreditHours = 3, TeacherId = 1 },
                new Course { Id = 2, Title = "Database Systems", CreditHours = 4, TeacherId = 2 },
                new Course { Id = 3, Title = "Web Development", CreditHours = 3, TeacherId = 1 }
            );

            
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, CourseId = 1, EnrollmentDate = new DateTime(2026, 9, 1), Grade = 90.00m },
                new Enrollment { Id = 2, StudentId = 2, CourseId = 2, EnrollmentDate = new DateTime(2026, 9, 2), Grade = 85.50m },
                new Enrollment { Id = 3, StudentId = 3, CourseId = 3, EnrollmentDate = new DateTime(2026, 9, 3), Grade = null }
            );
        }



    }


    
}

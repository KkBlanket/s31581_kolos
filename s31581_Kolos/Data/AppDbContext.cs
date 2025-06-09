using s31581_Kolos.Models;

namespace s31581_Kolos.Data;

using Microsoft.EntityFrameworkCore;


public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var student1 = new Student
        {
            Id = 1,
            FirstName = "Marcin",
            LastName = "Wadys",
            Email = "marcin.wadys@wp.pl"

        };

        var student2 = new Student
        {
            Id = 2,
            FirstName = "Adam",
            LastName = "Wiśniewski",
            Email = "adam.w@wp.pl"
        };
        
        var course1 = new Course
        {
            Id = 101,
            Title = "Java",
            Teacher = "dr Kowalski"
        };
        
        var course2 = new Course
        {
            Id = 102,
            Title = "Bazy Danych",
            Teacher = "mgr Adamczyk"
        };

        var enrollment1 = new Enrollment
        {
            CourseId = course1.Id,
            StudentId = student1.Id,
            EnrollmentDate = DateTime.Parse("2022-09-01T12:00:00")
        };
        
        var enrollment2 = new Enrollment
        {
            CourseId = course2.Id,
            StudentId = student2.Id,
            EnrollmentDate = DateTime.Parse("2023-11-02T09:30:00")
        };
        
        modelBuilder.Entity<Student>().HasData(student1);
        modelBuilder.Entity<Student>().HasData(student2);
        modelBuilder.Entity<Course>().HasData(course1);
        modelBuilder.Entity<Course>().HasData(course2);
        modelBuilder.Entity<Enrollment>().HasData(enrollment1);
        modelBuilder.Entity<Enrollment>().HasData(enrollment2);
    }
}
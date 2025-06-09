using Microsoft.EntityFrameworkCore;
using s31581_Kolos.Data;
using s31581_Kolos.DTO_s;
using s31581_Kolos.Exceptions;
using s31581_Kolos.Models;

namespace s31581_Kolos.Services;

public interface IDbService
{
    Task<IEnumerable<CourseGetDto>> GetAllCourses();
    Task<StudentCreateResponseDto> CreateStudent(StudentCreateDto studentCreateDto);
}
public class DbService(AppDbContext context) : IDbService
{
    public async Task<IEnumerable<CourseGetDto>> GetAllCourses()
    {
        var courses = await context.Courses
            .Include(e => e.Enrollments)
            .ThenInclude(e => e.Student)
            .ToListAsync();

        if (courses.Count == 0)
        {
            throw new NotFoundException("No enrollments found");
        }

        return courses.Select(c => new CourseGetDto
        {
            Id = c.Id,
            Title = c.Title,
            Teacher = c.Teacher,
            Students = c.Enrollments.Select(e => new StudentResponseDto
            {
                Id = e.Student.Id,
                FirstName = e.Student.FirstName,
                LastName = e.Student.LastName,
                Email = e.Student.Email,
                EnrollmentDate = e.EnrollmentDate
            }).ToList()
        }).ToList();
    }
    public async Task<StudentCreateResponseDto> CreateStudent(StudentCreateDto studentCreateDto)
    {
        var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var student = new Student
            {
                FirstName = studentCreateDto.FirstName,
                LastName = studentCreateDto.LastName,
                Email = studentCreateDto.Email,
            };
            

            context.Students.Add(student);
            
            await context.SaveChangesAsync();

            var courses = new List<CourseResponseDto>();

            if (studentCreateDto.Courses == null)
            {
                throw new NotFoundException("No courses found");
            }

            foreach (var courseDto in studentCreateDto.Courses)
            {
                var course = await context.Courses
                    .FirstOrDefaultAsync(c => c.Title == courseDto.Title &&
                                              c.Credits == courseDto.Credits &&
                                              c.Teacher == courseDto.Teacher);

                if (course == null)
                {
                    course = new Course
                    {
                        Title = courseDto.Title,
                        Credits = courseDto.Credits,
                        Teacher = courseDto.Teacher
                    };
                    context.Courses.Add(course);
                    await context.SaveChangesAsync();
                }

                var enrollment = new Enrollment
                {
                    Student = student,
                    Course = course,
                    EnrollmentDate = DateTime.Now
                };

                context.Enrollments.Add(enrollment);

                courses.Add(new CourseResponseDto
                {
                    Id = course.Id,
                    Title = course.Title,
                    Credits = course.Credits,
                    Teacher = course.Teacher
                });
            }

            await context.SaveChangesAsync();
            
            await transaction.CommitAsync();
            
            return new StudentCreateResponseDto()
            {
                Student = new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email
                },
                Courses = courses
            };
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
namespace s31581_Kolos.DTO_s;

public class StudentCreateDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public List<CourseCreateDto>? Courses { get; set; } = null!;
}
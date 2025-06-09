namespace s31581_Kolos.DTO_s;

public class StudentCreateResponseDto
{
    public StudentDto Student { get; set; } = null!;
    public List<CourseResponseDto> Courses { get; set; } = null!;
}
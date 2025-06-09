namespace s31581_Kolos.DTO_s;

public class CourseCreateDto
{
    public string Title { get; set; } = null!;
    public string? Credits { get; set; }
    public string Teacher { get; set; } = null!;
}
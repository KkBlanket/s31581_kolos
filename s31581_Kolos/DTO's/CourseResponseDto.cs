namespace s31581_Kolos.DTO_s;

public class CourseResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Credits { get; set; }
    public string Teacher { get; set; } = null!;
}
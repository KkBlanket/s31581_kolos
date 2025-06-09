using s31581_Kolos.Models;

namespace s31581_Kolos.DTO_s;

public class CourseGetDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Teacher { get; set; } = null!;
    public List<StudentResponseDto> Students { get; set; } = null!;
}
namespace s31581_Kolos.DTO_s;

public class StudentResponseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
}
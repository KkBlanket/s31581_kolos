using System.ComponentModel.DataAnnotations;

namespace s31581_Kolos.Models;

public class Course
{
    [Key] public int Id { get; set; }
    [MaxLength(150)]public String Title { get; set; } = null!;
    [MaxLength(300)]public String? Credits { get; set; } = null!; 
    [MaxLength(150)] public String Teacher { get; set; } = null!;
    public virtual ICollection<Enrollment> Enrollments { get; set; } = null!;
}
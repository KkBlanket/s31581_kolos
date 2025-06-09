using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace s31581_Kolos.Models;

[PrimaryKey(nameof(CourseId), nameof(StudentId))]
public class Enrollment
{
    [Column("Student_ID")] public int StudentId { get; set; }
    
    [Column("Course_ID")] public int CourseId { get; set; }
    
    [ForeignKey(nameof(CourseId))] public virtual Course Course { get; set; } = null!;
    
    [ForeignKey(nameof(StudentId))] public virtual Student Student { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }
}
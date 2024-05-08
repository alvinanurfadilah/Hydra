using System.ComponentModel.DataAnnotations;

namespace HydraApi.DTOs.Courses;

public class CourseUpdateDTO
{
    public string Id { get; set; } = null!;
    [Required]
    public DateTime EndDate { get; set; }
}

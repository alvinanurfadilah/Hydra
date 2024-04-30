namespace HydraApi.DTOs.Bootcamps;

public class BootcampResponseDTO
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

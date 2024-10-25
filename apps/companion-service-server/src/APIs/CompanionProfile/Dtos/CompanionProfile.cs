namespace CompanionService.APIs.Dtos;

public class CompanionProfile
{
    public bool? Availability { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public double? HourlyRate { get; set; }

    public string Id { get; set; }

    public double? Ratings { get; set; }

    public DateTime UpdatedAt { get; set; }
}

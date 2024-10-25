namespace CompanionService.APIs.Dtos;

public class SessionCreateInput
{
    public string? ClientId { get; set; }

    public string? CompanionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? Duration { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Id { get; set; }

    public double? Price { get; set; }

    public List<Review>? Reviews { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime UpdatedAt { get; set; }
}

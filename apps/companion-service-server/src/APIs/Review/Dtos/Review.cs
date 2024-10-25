namespace CompanionService.APIs.Dtos;

public class Review
{
    public string? Comments { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public int? Rating { get; set; }

    public string? Session { get; set; }

    public DateTime UpdatedAt { get; set; }
}

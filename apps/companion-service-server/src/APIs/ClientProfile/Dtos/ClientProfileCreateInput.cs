namespace CompanionService.APIs.Dtos;

public class ClientProfileCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Preferences { get; set; }

    public DateTime UpdatedAt { get; set; }
}
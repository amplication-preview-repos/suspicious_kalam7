using CompanionService.Core.Enums;

namespace CompanionService.APIs.Dtos;

public class UserWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public string? Location { get; set; }

    public string? Password { get; set; }

    public List<string>? Payments { get; set; }

    public RoleEnum? Role { get; set; }

    public string? Roles { get; set; }

    public List<string>? Subscriptions { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Username { get; set; }
}

using CompanionService.Core.Enums;

namespace CompanionService.APIs.Dtos;

public class UserCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public string? Location { get; set; }

    public string Password { get; set; }

    public List<Payment>? Payments { get; set; }

    public RoleEnum? Role { get; set; }

    public string Roles { get; set; }

    public List<Subscription>? Subscriptions { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Username { get; set; }
}

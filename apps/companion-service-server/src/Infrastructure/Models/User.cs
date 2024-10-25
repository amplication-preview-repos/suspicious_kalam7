using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanionService.Core.Enums;

namespace CompanionService.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    [StringLength(1000)]
    public string? Location { get; set; }

    [Required()]
    public string Password { get; set; }

    public List<PaymentDbModel>? Payments { get; set; } = new List<PaymentDbModel>();

    public RoleEnum? Role { get; set; }

    [Required()]
    public string Roles { get; set; }

    public List<SubscriptionDbModel>? Subscriptions { get; set; } = new List<SubscriptionDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    public string Username { get; set; }
}

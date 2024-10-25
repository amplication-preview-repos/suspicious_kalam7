using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanionService.Core.Enums;

namespace CompanionService.Infrastructure.Models;

[Table("Subscriptions")]
public class SubscriptionDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? EndDate { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public DateTime? StartDate { get; set; }

    public StatusEnum? Status { get; set; }

    public SubscriptionTypeEnum? SubscriptionType { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}

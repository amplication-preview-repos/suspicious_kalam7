using CompanionService.Core.Enums;

namespace CompanionService.APIs.Dtos;

public class Subscription
{
    public DateTime CreatedAt { get; set; }

    public DateTime? EndDate { get; set; }

    public string Id { get; set; }

    public DateTime? StartDate { get; set; }

    public StatusEnum? Status { get; set; }

    public SubscriptionTypeEnum? SubscriptionType { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
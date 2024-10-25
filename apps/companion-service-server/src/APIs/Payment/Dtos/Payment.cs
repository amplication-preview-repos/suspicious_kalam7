using CompanionService.Core.Enums;

namespace CompanionService.APIs.Dtos;

public class Payment
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public DateTime? PaymentDate { get; set; }

    public PaymentMethodEnum? PaymentMethod { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
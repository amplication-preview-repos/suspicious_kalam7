using CompanionService.Core.Enums;

namespace CompanionService.APIs.Dtos;

public class PaymentCreateInput
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? PaymentDate { get; set; }

    public PaymentMethodEnum? PaymentMethod { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}

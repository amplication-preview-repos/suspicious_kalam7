using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanionService.Infrastructure.Models;

[Table("CompanionProfiles")]
public class CompanionProfileDbModel
{
    public bool? Availability { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Range(-999999999, 999999999)]
    public double? HourlyRate { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public double? Ratings { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}

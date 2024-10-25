using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanionService.Infrastructure.Models;

[Table("Sessions")]
public class SessionDbModel
{
    [StringLength(1000)]
    public string? ClientId { get; set; }

    [StringLength(1000)]
    public string? CompanionId { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Range(-999999999, 999999999)]
    public int? Duration { get; set; }

    public DateTime? EndTime { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public double? Price { get; set; }

    public List<ReviewDbModel>? Reviews { get; set; } = new List<ReviewDbModel>();

    public DateTime? StartTime { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanionService.Infrastructure.Models;

[Table("Reviews")]
public class ReviewDbModel
{
    [StringLength(1000)]
    public string? Comments { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? Rating { get; set; }

    public string? SessionId { get; set; }

    [ForeignKey(nameof(SessionId))]
    public SessionDbModel? Session { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }
}

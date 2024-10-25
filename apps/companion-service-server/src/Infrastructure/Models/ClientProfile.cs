using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanionService.Infrastructure.Models;

[Table("ClientProfiles")]
public class ClientProfileDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Preferences { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}

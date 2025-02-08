using System.ComponentModel.DataAnnotations;

namespace ProductClient.API.Entities;

public class EntityBase
{
    [Key]
    [Required]
    public long Id { get; set; }
}

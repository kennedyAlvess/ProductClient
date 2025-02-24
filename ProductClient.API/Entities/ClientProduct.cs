using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace ProductClient.API.Entities;

[Index(nameof(ClientId))]
[Index(nameof(ProductId))]
[Table("ClientProducts")]
public class ClientProduct : EntityBase
{
    [Required]
    public long ClientId { get; set; }
    [Required]
    public long ProductId { get; set; }
    [Required]
    public long Quantidade { get; set; }
    [Required]
    public decimal ValorTotal { get; set; }
    [Required]
    public Client Client { get; set; } = null!;
    [Required]
    public Product Product { get; set; } = null!;
}

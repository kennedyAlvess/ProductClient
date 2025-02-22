using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductClient.API.Entities;

[Index(nameof(Descricao), IsUnique = false)]
[Table("Products")]
public class Product : EntityBase
{
    [Required]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public string Marca { get; set; } = string.Empty;
    [Required]
    public decimal ValorUnitario { get; set; }
    public ICollection<ClientProduct> ClientProducts { get; set; } = [];
}

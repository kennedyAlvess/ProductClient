using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductClient.API.Entities
{
    [Index(nameof(Cpf), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Table("Clients")]
    public class Client : EntityBase
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateOnly DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; } = string.Empty;
        public int Idade { get; private set; }
        public ICollection<ClientProduct> ClientProducts { get; set; } = [];
    }
}
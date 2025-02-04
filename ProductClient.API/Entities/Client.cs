using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ProductClient.Communication.RequestsDTO;

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
        public long UsuarioCadastro { get; set; }
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; } = string.Empty;
        public int Idade { get; private set; }
        public ICollection<ClientProduct> ClientProducts { get; set; } = [];

        public Client(RequestClient client)
        {
            Nome = client.Nome;
            Email = client.Email;
            DataNascimento = client.DataNascimento;
            UsuarioCadastro = client.UsuarioCadastro;
            Cpf = client.Cpf;
            DataCadastro = DateTime.Now;
        }
    }
}
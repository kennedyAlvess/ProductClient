using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductClient.API.Entities
{
    [Index(nameof(ClientId))]
    [Index(nameof(ProductId))]
    [Table("ClientProducts")]
    public class ClientProduct : EntityBase
    {
        public long ClientId { get; set; }
        public long ProductId { get; set; }
        public long Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public Client Client { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
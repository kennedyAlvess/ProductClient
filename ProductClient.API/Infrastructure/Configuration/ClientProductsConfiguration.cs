using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductClient.API.Entities;

namespace ProductClient.API.Infrastructure.Configuration
{
    public class ClientProductsConfiguration : IEntityTypeConfiguration<ClientProduct>
    {
        public void Configure(EntityTypeBuilder<ClientProduct> builder)
        {
            builder.HasKey(cp => new { cp.ClientId, cp.ProductId });

            builder.HasOne(cp => cp.Client)
                   .WithMany(c => c.ClientProducts)
                   .HasForeignKey(cp => cp.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cp => cp.Product)
                   .WithMany(p => p.ClientProducts)
                   .HasForeignKey(cp => cp.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
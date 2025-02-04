using Microsoft.EntityFrameworkCore;
using ProductClient.API.Entities;

namespace ProductClient.API.Infrastructure.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.Idade)
                    .HasComputedColumnSql("DATEDIFF(YEAR, DataNascimento, GETDATE())");
        }
    }

}
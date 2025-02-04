using Microsoft.EntityFrameworkCore;
using ProductClient.API.Entities;

namespace ProductClient.API.Infrastructure
{
    public class ProductClienteDbContext : DbContext
    {
        public ProductClienteDbContext(DbContextOptions<ProductClienteDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientProduct> ClientProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductClienteDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
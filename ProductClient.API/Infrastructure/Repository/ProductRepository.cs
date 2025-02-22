using Microsoft.EntityFrameworkCore;
using ProductClient.API.Entities;

namespace ProductClient.API.Infrastructure.Repository
{
    public interface IProductRepository
    {
        Task Add(Product entity);
        Task Update(Product entity);
        Task Deletar(long id);
        Task<Product?> GetProductById(long id);
        Task<List<Product>> GetAllProducts();
        Task<bool> ProducteExiste(long id);
        Task SaveChangesAsync();

    }
    public class ProductRepository(ProductClienteDbContext context) : IProductRepository
    {
        private readonly ProductClienteDbContext _context = context;

        public async Task Add(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(long id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity is not null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(long id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Update(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ProducteExiste(long id)
        {
            return await _context.Products.AnyAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
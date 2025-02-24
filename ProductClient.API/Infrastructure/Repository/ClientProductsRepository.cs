using Microsoft.EntityFrameworkCore;
using ProductClient.API.Entities;

namespace ProductClient.API.Infrastructure.Repository;

public interface IClientProductsRepository
{
    Task<List<ClientProduct>> GetClientsProducts(long Id);
    Task<ClientProduct> GetClientProduct(long Id);
    Task InsertClientProduct(ClientProduct clientProduct);
    Task DeleteClientProduct(ClientProduct clientProduct);
    Task SaveChangesAsync();
}

class ClientProductsRepository(ProductClienteDbContext context) : IClientProductsRepository
{
    private readonly ProductClienteDbContext _context = context;

    public async Task DeleteClientProduct(ClientProduct clientProduct)
    {
        _context.ClientProducts.Remove(clientProduct);
        await _context.SaveChangesAsync();
    }
    public async Task<ClientProduct> GetClientProduct(long Id)
    {
        var clientsProducts = await _context.ClientProducts.FindAsync(Id);

        return clientsProducts!;
    }

    public async Task<List<ClientProduct>> GetClientsProducts(long Id)
    {
        var clientsProducts = await _context.ClientProducts
            .Where(cp => cp.ClientId == Id)
            .Include(cp => cp.Client)
            .Include(cp => cp.Product)
            .AsNoTracking()
            .ToListAsync();

        return clientsProducts;
    }

    public async Task InsertClientProduct(ClientProduct clientProduct)
    {
        await _context.ClientProducts.AddAsync(clientProduct);
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
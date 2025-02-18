using Microsoft.EntityFrameworkCore;
using ProductClient.API.Entities;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Infrastructure.Repository;

public interface IClientProductsRepository
{
    Task<List<ClientProduct>> GetClientsProducts(long Id);
}

class ClientProductsRepository(ProductClienteDbContext context) : IClientProductsRepository
{
    private readonly ProductClienteDbContext _context = context;
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
}
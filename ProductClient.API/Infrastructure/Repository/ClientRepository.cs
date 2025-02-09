using Microsoft.EntityFrameworkCore;
using ProductClient.API.Entities;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Infrastructure.Repository
{
    public interface IClientRepository
    {
        Task<Client> Add(Client entity);
        Task<Client> Update(Client entity);
        Task Deletar(long id);
        Task<Client?> GetClientById(long id);
        Task<List<Client>> GetAllClients();
        Task<bool> ClienteExiste(long id);

    }
    public class ClientRepository(ProductClienteDbContext context) : IClientRepository
    {
        private readonly ProductClienteDbContext _context = context;

        public async Task<Client> Add(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Deletar(long id)
        {
            var entity = await _context.Clients.FindAsync(id);
            if (entity is not null)
            {
                _context.Clients.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetClientById(long id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> Update(Client entity)
        {
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ClienteExiste(long id)
        {
            return await _context.Clients.AnyAsync(e => e.Id == id);
        }
    }
}
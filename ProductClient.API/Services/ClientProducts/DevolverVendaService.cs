using ProductClient.API.Infrastructure.Repository;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.ClientProducts;


public interface IDevolverVendaService
{
    Task Executar(long Id);
}

public class DevolverVendaService : IDevolverVendaService
{
    private readonly IClientProductsRepository _clientProductsRepository;
    public DevolverVendaService(IClientProductsRepository clientProductsRepository)
    {
        _clientProductsRepository = clientProductsRepository;
    }
    public async Task Executar(long Id)
    {
        var clientProduct = await _clientProductsRepository.GetClientProduct(Id) ?? throw new NotFoundException("Venda não encontrada.");

        await _clientProductsRepository.DeleteClientProduct(clientProduct);

        await _clientProductsRepository.SaveChangesAsync();
    }
}

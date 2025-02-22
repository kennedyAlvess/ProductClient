using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.ClientProducts;

public interface IDevolverProdutos
{
    Task Executar(RequestClientProducts request, long Id);
}

public class DevolverProdutos : IDevolverProdutos
{
    private readonly IClientProductsRepository _clientProductsRepository;
    public DevolverProdutos(IClientProductsRepository clientProductsRepository)
    {
        _clientProductsRepository = clientProductsRepository;
    }
    public async Task Executar(RequestClientProducts request, long Id)
    {
        var clientProduct = await _clientProductsRepository.GetClientProduct(Id) ?? throw new NotFoundException("Cliente não encontrado.");

        if(clientProduct.Quantidade < request.Quantidade)
        {
            throw new BadRequestException("Quantidade de produtos a ser devolvida é maior que a quantidade de produtos existentes.");
        }
        
        clientProduct.Quantidade -= request.Quantidade;

        await _clientProductsRepository.SaveChangesAsync();        
    }
}

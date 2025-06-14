using ProductClient.API.Infrastructure.Repository;
using ProductClient.Communication.ResponseDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.ClientProducts;

public interface IListClientSalesOrderService
{
    Task<List<ResponseClientProducts>> Execute(long Id);
}

public class ListClientSalesOrderService(IClientProductsRepository clientProductsRepository) : IListClientSalesOrderService
{
    private readonly IClientProductsRepository _clientProductsRepository = clientProductsRepository;
    public async Task<List<ResponseClientProducts>> Execute(long Id)
    {
        var result = await _clientProductsRepository.GetClientsProducts(Id);
        
        if(result.Count == 0)
            throw new NotFoundException("Cliente não possui produtos vinculados.");

        return [.. result.Select(x => new ResponseClientProducts
        {
            Cliente = x.Client.Nome,
            Produto = x.Product.Descricao,
            Quantidade = x.Quantidade,
            Marca = x.Product.Marca,
            ValorTotal = x.ValorTotal,
            ValorUnitario = x.Product.ValorUnitario
        } )];
    }
}
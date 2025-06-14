using ProductClient.API.Infrastructure.Repository;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.ClientProducts;


public interface IRefundSalesOrderService
{
    Task Execute(long Id);
}

public class refundSalesOrderServiceService(IClientProductsRepository clientProductsRepository) : IRefundSalesOrderService
{
    private readonly IClientProductsRepository _clientProductsRepository = clientProductsRepository;

    public async Task Execute(long Id)
    {
        var clientProduct = await _clientProductsRepository.GetClientProduct(Id) ?? throw new NotFoundException("Venda não encontrada.");

        await _clientProductsRepository.DeleteClientProduct(clientProduct);

        await _clientProductsRepository.SaveChangesAsync();
    }
}

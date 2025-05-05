using ProductClient.API.Infrastructure.Repository;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Products;

public interface IDeletarProdutoService
{
    Task Execute(long id);
}

class DeletarProdutoService(IProductRepository ProductRepository) : IDeletarProdutoService
{
    private readonly IProductRepository _ProductRepository = ProductRepository;

    public async Task Execute(long id)
    {
        if (!await _ProductRepository.ProducteExiste(id)) throw new NotFoundException("Produto não encontrado.");

        await _ProductRepository.Deletar(id);
    }
}

using ProductClient.Communication.RequestsDTO;

namespace ProductClient.API.Entities.CustomConvert;
public static class ConvertDTO
{
    public static Client ToClient(RequestClient requestClient)
    {
        return new Client
        {
            Nome = requestClient.Nome,
            Email = requestClient.Email,
            DataNascimento = requestClient.DataNascimento!,
            DataCadastro = DateTime.Now,
            Cpf = requestClient.Cpf!.Replace(".", "").Replace("-", "")
        };
    }

    public static ClientProduct ToClientProduct(RequestClientProducts requestClientProducts)
    {
        return new ClientProduct
        {
            ClientId = requestClientProducts.ClientId,
            ProductId = requestClientProducts.ProductId,
            Quantidade = requestClientProducts.Quantidade
        };
    }

    public static Product ToProduct(RequestProduct requestProduct)
    {
        return new Product
        {
            Descricao = requestProduct.Descricao,
            Marca = requestProduct.Marca,
            ValorUnitario = requestProduct.ValorUnitario
        };
    }
}

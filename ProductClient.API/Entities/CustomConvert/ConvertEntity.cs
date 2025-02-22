using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;
using ProductClient.Communication.Utils;

namespace ProductClient.API.Entities.CustomConvert;


public static class ConvertEntity
{
    public static ResponseClient ToClientResponse(Client client)
    {
        return new ResponseClient
        {
            Id = client.Id,
            Nome = client.Nome,
            Email = Mascaras.MascaraEmail(client.Email),
            DataNascimento = client.DataNascimento,
            Cpf = Mascaras.MascaraCpf(client.Cpf),
            Idade = client.Idade
        };
    }
    public static RequestClient ToClientRequest(Client client)
    {
        return new RequestClient
        {
            Id = client.Id,
            Nome = client.Nome,
            Email =client.Email,
            DataNascimento = client.DataNascimento,
            Cpf = client.Cpf,
            DataCadastro = client.DataCadastro
        };
    }
    public static ResponseProduct ToProductResponse(Product product)
    {
        return new ResponseProduct
        {
            Descricao = product.Descricao,
            Marca = product.Marca,
            ValorUnitario = product.ValorUnitario
        };
    }

}
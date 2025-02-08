using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Entities.CustomConvert;

public static class ConvertEntity
{
    public static ResponseClient ToClientResponse(Client client)
    {
        return new ResponseClient
        {
            Id = client.Id,
            Nome = client.Nome,
            Email = client.Email,
            DataNascimento = client.DataNascimento,
            Cpf = client.Cpf,
            Idade = client.Idade
        };
    }
}
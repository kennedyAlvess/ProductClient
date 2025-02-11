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
}
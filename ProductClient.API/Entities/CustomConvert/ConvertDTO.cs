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
            DataNascimento = (DateOnly)requestClient.DataNascimento!,
            DataCadastro = DateTime.Now,
            Cpf = requestClient.Cpf.Replace(".", "").Replace("-", "")
        };
    }
}

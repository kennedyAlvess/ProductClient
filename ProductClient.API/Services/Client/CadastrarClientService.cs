using ProductClient.API.Validations;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;
using ProductCliente.Exceptions.ExceptionsBase;

namespace ProductClient.API.Services.Client;

public class CadastrarClientService
{
    public ResponseClient Executar(RequestClient client)
    {
        var validator = new ClientValidation();
        var result = validator.Validate(client);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(erros => erros.ErrorMessage).ToList();
            throw new ArgumentException();
        }
        return new ResponseClient();
    }
}
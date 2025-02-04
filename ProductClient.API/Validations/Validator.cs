using ProductClient.Communication.RequestsDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Validations
{
    public static class Validator
    {
        public static void ExecuteValidation(RequestClient client)
        {
            var result = new ClientValidation().Validate(client);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(erros => erros.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
        }
    }
}
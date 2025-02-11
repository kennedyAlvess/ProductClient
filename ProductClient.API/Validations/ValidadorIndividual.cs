using FluentValidation;
using ProductClient.API.Validations.CustomValitadion;
using ProductClient.Communication.RequestsDTO;
using FluentValidation.Results;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Validations;

public class ValidadorIndividual : AbstractValidator<RequestClient>
{
    public static void Validar(string propriedade, RequestClient client)
    {
        switch (propriedade)
        {
            case "Nome":
                Error(new ValidadorNome().Validate(client));
                break;
            case "Email":
                Error(new ValidadorEmail().Validate(client));
                break;
            case "Cpf":
                Error(new ValidadorCpf().Validate(client));
                break;
            case "DataNascimento":
                Error(new ValidadorDataNascimento().Validate(client));
                break;
            default:
                break;
        }
    }
    public class ValidadorCpf : AbstractValidator<RequestClient>
    {
        public ValidadorCpf()
        {
            RuleFor(requestClient => requestClient.Cpf).CpfValidation();
        }
    }

    public class ValidadorDataNascimento : AbstractValidator<RequestClient>
    {
        public ValidadorDataNascimento()
        {
            RuleFor(requestClient => requestClient.DataNascimento).DataNascimentoValidation();
        }
    }

    public class ValidadorNome : AbstractValidator<RequestClient>
    {
        public ValidadorNome()
        {
            RuleFor(requestClient => requestClient.Nome).NotEmpty().WithMessage("Nome inválido.");
        }
    }

    public class ValidadorEmail : AbstractValidator<RequestClient>
    {
        public ValidadorEmail()
        {
            RuleFor(requestClient => requestClient.Email).EmailAddress().WithMessage("E-mail inválido.");
        }
    }

    private static void Error(ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(erros => erros.ErrorMessage).ToList();
            throw new ExceptionValidation(errors);
        }
    }
}

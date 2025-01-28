using FluentValidation;

namespace ProductClient.API.Validations.CustomValitadion;

public static class CustonsValitadions
{
    public static IRuleBuilderOptionsConditions<T, DateTime> DataNascimentoValidation<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder
    )
    {
        return ruleBuilder.Custom((dataNascimento, context) =>
        {
            var today = DateTime.Today;

            if (dataNascimento == default)
            {
                context.AddFailure("Data Nascimento inválida.");
                return;
            }
                
            if (dataNascimento > today)
                context.AddFailure("A data de nascimento não pode ser maior que a data atual.");
            
            var idade = dataNascimento.Year - today.Year;
            if(idade < 18)
                context.AddFailure("O cliente deve ser maior de 18 anos.");
        });
    }
}
using FluentValidation;

namespace ProductClient.API.Validations.CustomValitadion;

public static class CustonsValitadions
{
    public static IRuleBuilderOptionsConditions<T, DateOnly> DataNascimentoValidation<T>(
        this IRuleBuilder<T, DateOnly> ruleBuilder
    )
    {
        return ruleBuilder.Custom((dataNascimento, context) =>
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            if (dataNascimento == default)
            {
                context.AddFailure("Data Nascimento inválida.");
                return;
            }
                
            if (dataNascimento > today)
                context.AddFailure("A data de nascimento não pode ser maior que a data atual.");
            
            var idade = today.Year - dataNascimento.Year;
            if(idade < 18)
                context.AddFailure("O cliente deve ser maior de 18 anos.");
        });
    }
}
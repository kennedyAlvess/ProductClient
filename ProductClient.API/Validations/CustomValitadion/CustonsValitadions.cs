using FluentValidation;

namespace ProductClient.API.Validations.CustomValitadion;

public static class CustonsValitadions
{
    public static IRuleBuilderOptionsConditions<T, string> CpfValidation<T>(
        this IRuleBuilder<T, string> ruleBuilder
    )
    {
        return ruleBuilder.Custom((cpf, context) =>
        {
            if (!ValidaCpf(cpf))
                context.AddFailure("CPF inválido.");
        });
    }
    public static IRuleBuilderOptionsConditions<T, DateOnly?> DataNascimentoValidation<T>(
        this IRuleBuilder<T, DateOnly?> ruleBuilder
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
#nullable disable
            var idade = today.Year - dataNascimento.Value.Year;
            if (idade < 18)
                context.AddFailure("O cliente deve ser maior de 18 anos.");
        });
    }

    private static bool ValidaCpf(string cpf)
    {
        int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

        cpf = cpf.Trim().Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;

        for (int j = 0; j < 10; j++)
            if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                return false;

        string tempCpf = cpf[..9];
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        string digito = resto.ToString();
        tempCpf += digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto.ToString();

        return cpf.EndsWith(digito);
    }
}

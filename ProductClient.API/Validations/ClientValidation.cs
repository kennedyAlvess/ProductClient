﻿using FluentValidation;
using ProductClient.API.Validations.CustomValitadion;
using ProductClient.Communication.RequestsDTO;

namespace ProductClient.API.Validations;

public class ClientValidation : AbstractValidator<RequestClient>
{
    public ClientValidation()
    {
        RuleFor(requestClient => requestClient.Nome).NotEmpty().WithMessage("Nome inválido.");
        RuleFor(requestClient => requestClient.Email).EmailAddress().WithMessage("E-mail inválido.");
        RuleFor(requestClient => requestClient.Cpf).CpfValidation();
        RuleFor(requestClient => requestClient.DataNascimento).DataNascimentoValidation();
    }
}

public class ClientAtualizarValidation : AbstractValidator<RequestAtualizarClient>
{
    public ClientAtualizarValidation()
    {
        RuleFor(requestClient => requestClient.Nome).NotEmpty().WithMessage("Nome inválido.");
        RuleFor(requestClient => requestClient.DataNascimento).DataNascimentoValidation();
    }
}
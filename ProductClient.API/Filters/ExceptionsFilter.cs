using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClient.Communication.ResponseDTO;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ExceptionBase exception)
        {
            context.Result = new ObjectResult( new Response<List<string>>(exception.GetErrorsMessages()));
            context.HttpContext.Response.StatusCode = (int)exception.GetStatusCode();

        }
        else
        {
            context.Result = new ObjectResult(new ResponseErros(["Um erro ocorreu a processar sua ação", "Entre em contato com o Suporte Técnico."]));
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}

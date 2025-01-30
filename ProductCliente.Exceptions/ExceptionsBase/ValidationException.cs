using System.Net;

namespace ProductCliente.Exceptions.ExceptionsBase;

public class ValidationException : ExceptionBase
{
    private readonly List<string> _errors;
    
    public ValidationException(List<string> errorMessages) : base(String.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrorsMessages() => _errors;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
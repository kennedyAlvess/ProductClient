using System.Net;

namespace ProductClient.Exceptions.ExceptionsBase;

public class ExceptionValidation : ExceptionBase
{
    private readonly List<string> _errors;
    
    public ExceptionValidation(List<string> errorMessages) : base(String.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrorsMessages() => _errors;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
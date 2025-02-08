using System.Net;

namespace ProductClient.Exceptions.ExceptionsBase;

public class ExceptionValidation(List<string> errorMessages) : ExceptionBase(String.Empty)
{
    private readonly List<string> _errors = errorMessages;

    public override List<string> GetErrorsMessages() => _errors;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
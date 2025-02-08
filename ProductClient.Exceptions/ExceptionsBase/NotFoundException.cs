using System.Net;

namespace ProductClient.Exceptions.ExceptionsBase;

public class NotFoundException(string errorMessages) : ExceptionBase(errorMessages)
{
    public override List<string> GetErrorsMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}
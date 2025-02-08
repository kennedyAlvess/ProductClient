using System.Net;

namespace ProductClient.Exceptions.ExceptionsBase;

public class NotFoundException : ExceptionBase
{
    public NotFoundException(string errorMessages) : base(errorMessages)
    {
    }

    public override List<string> GetErrorsMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}
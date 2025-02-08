using System.Net;

namespace ProductClient.Exceptions.ExceptionsBase;

public abstract class ExceptionBase(string errorMessage) : SystemException(errorMessage)
{
    public abstract List<string> GetErrorsMessages();
    public abstract HttpStatusCode GetStatusCode();
}
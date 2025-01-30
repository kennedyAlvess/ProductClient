using System.Net;

namespace ProductClient.Exceptions.ExceptionsBase;

public abstract class ExceptionBase : SystemException
{
    public ExceptionBase(string errorMessage) : base(errorMessage)
    {
    }
    
    public abstract List<string> GetErrorsMessages();
    public abstract HttpStatusCode GetStatusCode();
}
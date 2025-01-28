namespace ProductCliente.Exceptions.ExceptionsBase;

public abstract class ProductClientException : SystemException
{
    public ProductClientException(string errorMessage) : base(errorMessage)
    {
    }
    
    public abstract List<string> GetErrorsMessages();
}
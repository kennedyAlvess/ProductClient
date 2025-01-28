namespace ProductCliente.Exceptions.ExceptionsBase;

public class ValidationException : ProductClientException
{
    private readonly List<string> _errors;
    
    public ValidationException(List<string> errorMessages) : base(String.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrorsMessages() => _errors;
}
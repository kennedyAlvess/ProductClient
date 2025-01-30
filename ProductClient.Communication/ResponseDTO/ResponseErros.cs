
namespace ProductClient.Communication.ResponseDTO;

public class ResponseErros
{
    public List<string> Erros { get; private set; }

    public ResponseErros(string error)
    {
        Erros = [error];
    }
    public ResponseErros(List<string> erros)
    {
        Erros = erros;
    }
}
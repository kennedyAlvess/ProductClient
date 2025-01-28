namespace ProductClient.Communication.ResponseDTO;

public class ReponseErros
{
    public List<string> Erros { get; private set; }

    public ReponseErros(string error)
    {
        Erros = [error];
    }
    public ReponseErros(List<string> erros)
    {
        Erros = erros;
    }
}
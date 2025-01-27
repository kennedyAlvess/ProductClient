namespace ProductClient.Communication.ResponseDTO;

public class ClientResponse
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
}
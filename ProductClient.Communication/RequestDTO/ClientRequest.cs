namespace ProductClient.Communication.RequestDTO;

public class ClientRequest
{
    public string Nome  { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}
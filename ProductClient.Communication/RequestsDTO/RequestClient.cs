namespace ProductClient.Communication.RequestsDTO;

public class RequestClient
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    public DateTime DataCadastro { get; set; }
    public long UsuarioCadastro { get; set; }
    public string Cpf { get; set; } = string.Empty;

}
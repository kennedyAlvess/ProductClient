namespace ProductClient.Communication.ResponseDTO;

public class ResponseClient
{
    public string Nome { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public DateOnly? DataNascimento { get; set; }
    public string? Cpf { get; set; } = string.Empty;
    public int? Idade { get; set; }
}
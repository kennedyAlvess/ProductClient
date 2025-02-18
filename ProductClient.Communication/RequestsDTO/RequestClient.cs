using System.Text.Json.Serialization;

namespace ProductClient.Communication.RequestsDTO;

public class RequestClient
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    [JsonIgnore]
    public DateTime? DataCadastro { get; set; }
    public string? Cpf { get; set; } = string.Empty;
}

public class RequestAtualizarClient
{
    public string Nome { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
}
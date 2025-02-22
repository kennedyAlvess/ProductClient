namespace ProductClient.Communication.ResponseDTO;

public class ResponseProduct
{
    public string Descricao { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public decimal ValorUnitario { get; set; }
}
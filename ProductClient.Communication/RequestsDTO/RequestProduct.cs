namespace ProductClient.Communication.RequestsDTO;

public class RequestProduct
{
    public string Descricao { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public decimal ValorUnitario { get; set; }
}
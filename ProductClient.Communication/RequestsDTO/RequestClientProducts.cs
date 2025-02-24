namespace ProductClient.Communication.RequestsDTO;

public class RequestClientProducts
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public long ProductId { get; set; }
    public long Quantidade {get; set; }
}

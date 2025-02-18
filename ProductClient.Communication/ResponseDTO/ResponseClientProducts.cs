namespace ProductClient.Communication.ResponseDTO
{
    public class ResponseClientProducts
    {
        public string Cliente { get; set; } = string.Empty;
        public string Produto { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public long Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
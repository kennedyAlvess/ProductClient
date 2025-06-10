namespace ProductClient.Communication.ResponseDTO
{
    public class Response<T>
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public T Data { get; set; } = default!;
        public List<string> Errors { get; set; } = [];

        public Response(List<string> erros)
        {
            this.Message = "Falha ao executar o comando.";
            this.Success = false;
            this.Errors = erros;
        }
        public Response(T data, bool success)
        {
            this.Data = data;
            this.Message = "Comando executado com sucesso.";
            this.Success = success;
        }
    }
}

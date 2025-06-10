namespace ProductClient.Communication.ResponseDTO
{
    public class ResponseSuccess<T>(T data, string message = "Operação realizada com sucesso.")
    {
        public string Message { get; set; } = message;
        public bool Success { get; set; } = true;
        public T Data { get; set; } = data;
    }
}

namespace MSWadConsole20.Repository.DataModel.Response
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public int ErrorCode { get; set; }
        public string? UserMessage { get; set; }
    }
}

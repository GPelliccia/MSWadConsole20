namespace MSWadConsole20.Repository.DataAccess.DataModel.Response
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public int? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public string? UserMessage { get; set; }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T? Data { get; set; }
    }
}

namespace MSWadConsole20.Repository.DataModel.Response
{
    public class ApplicationResponse<T>
    {
        public T Dati { get; set; }
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}

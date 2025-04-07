using Dapper;

namespace MSWadConsole20.Repository.DataModel
{
    public class StoredData
    {
        public int? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }

        public StoredData() { }
        public StoredData(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        public void SetErrorResponse(DynamicParameters parameters)
        {
            ErrorCode = parameters.Get<int?>("@ErrorCode") ?? 0;
            ErrorMessage = parameters.Get<string>("@ErrorMsg");
        }
        public bool ThereIsNotError()
        {
            return ErrorCode == 0;
        }
    }  

    public class StoredData<T> : StoredData
    {
        public T? Data { get; set; }

        public StoredData() { }
        public StoredData(int errorCode, string errorMessage) : base(errorCode, errorMessage) { }
    }    
}

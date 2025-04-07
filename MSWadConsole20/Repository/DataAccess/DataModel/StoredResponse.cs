using Dapper;

namespace MSWadConsole20.Repository.DataAccess.DataModel
{
    public class StoredResponse
    {
        public int? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }

        public bool Success => ErrorCode == 0;

        public StoredResponse() { }
        public StoredResponse(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        public void SetErrorResponse(DynamicParameters parameters)
        {
            ErrorCode = parameters.Get<int>("@ErrorCode");
            ErrorMessage = parameters.Get<string>("@ErrorMsg");
        }
    }  

    public class StoredResponse<T> : StoredResponse
    {
        public T? Data { get; set; }
        public StoredResponse() { }
        public StoredResponse(int errorCode, string errorMessage) : base(errorCode, errorMessage) { }
    }    
}

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
    }  

        public class StoredData<T> : StoredData
        {
            public T? Data { get; set; }

            public StoredData() { }
            public StoredData(int errorCode, string errorMessage) : base(errorCode, errorMessage) { }
        }    
}

﻿using Azure;

namespace MSWadConsole20.Repository.DataModel.Response
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public int ErrorCode { get; set; }
        public string? UserMessage { get; set; }

        public ServiceResponse() { }

        public void SetServiceResponseFromStoredData(StoredData<T> storedData)
        {
            Data = storedData.Data;
            ErrorCode = storedData.ErrorCode.HasValue ? storedData.ErrorCode.Value : 0;
            Success = storedData.ThereIsNotError();
            UserMessage = storedData.ErrorMessage;
        }

        public void SetErrorOnCompletOperation()
        {
            Success = false;
            UserMessage = "Non è possibile completare l'operazione.";
        }
    }
}

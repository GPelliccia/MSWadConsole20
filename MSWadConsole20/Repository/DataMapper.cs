using MSWadConsole20.Contract.BusinessModel;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;

namespace MSWadConsole20.Repository
{
    public static class DataMapper
    {
        public static ServiceResponse<T?> ToServiceResponse<T>(this StoredResponse<T?> response)
        {
            return new ServiceResponse<T?>
            {
                Data = response.Data,
                Success = response.Success,
                ErrorCode = response.ErrorCode,
                ErrorMessage = response.ErrorMessage
            };
        }

        public static ServiceResponse ToServiceResponse(this StoredResponse response)
        {
            return new ServiceResponse
            {
                Success = response.Success,
                ErrorCode = response.ErrorCode,
                ErrorMessage = response.ErrorMessage
            };
        }

        public static LibraryModel ToLibraryModel(this LibraryData response)
        {
            return new LibraryModel
            {
                Id = response.LibreriaApplicazioneID,
                CodiceWAD = response.CodiceWAD,
                CodiceDimensions = response.CodiceDimensions,
                Descrizione = response.DescrizioneLibreria,
                Note = response.NoteLibreria,
                IsOffline = response.FlagOffline,
                DataInizioAttivazione = response.DataInizioAttivazione,
                DataFineAttivazione = response.DataFineAttivazione,
            };
        }
    }
}

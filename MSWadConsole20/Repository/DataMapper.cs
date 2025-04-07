using MSWadConsole20.Contract.BusinessModel;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;
using static MSWadConsole20.Repository.DataAccess.DataModel.Data.ParameterData;

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

        public static ReferentModel ToReferentModel(this ReferenteData response)
        {
            return new ReferentModel
            {
                Id = response.ReferenteId,
                Cognome = response.Cognome,
                Nome = response.Nome,
                Matricola = response.Matricola,
                CodiceFiscale = response.CodiceFiscale,
                Email = response.Email,
                Telefono = response.Telefono,
                Tipo = response.Tipo,
                Utenza = response.Utenza,
                DataInizioAttivazione = response.DataInizioAttivazione,
                DataFineAttivazione = response.DataInizioAttivazione,
                FlagDirigente = response.FlagDirigente,
                FlagDisabilitati = response.ConDisabilitati,
            };
        }

        public static TipoReferenteModel ToTipiReferentiModel(this TipoReferenteData response)
        {
            return new TipoReferenteModel
            {
                Id = response.TipoReferenteID,
                Nome = response.Nome,
                Abbreviazione = response.Abbreviazione,
            };
        }

        public static AmbienteModel ToAmbienteModel(this AmbienteData response)
        {
            return new AmbienteModel
            {
                Id = response.AmbienteId,
                Descrizione = response.Descrizione,
            };
        }



    }
}

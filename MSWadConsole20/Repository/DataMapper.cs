using Microsoft.EntityFrameworkCore.Query;
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


        public static ApplicationModel ToApplicationModel(this ApplicationData response)
        {
            return new ApplicationModel
            {
                Id = response.ApplicazioneId,
                LibreriaId = response.LibreriaApplicazioneId,
                CodiceWAD = response.CodiceWAD,
                CodiceDimensions = response.CodiceDimensions,
                Descrizione = response.DescrizioneApplicazione,
                DataInizioAttivazione = response.DataInizioAttivazione,
                DataFineAttivazione= response.DataFineAttivazione,
                FlagConsultazione = response.FlagConsultazione,
                FlagGestione = response.FlagGestione,
                FlagInternet = response.FlagInternet,
                FlagIntranet = response.FlagIntranet,
                Dominio = response.Dominio,
                Url = response.Url,
                NoteApplicazione = response.NoteApplicazione,
                Help64 = response.Help64,
                PiattaformaApplicazione = response.PiattaformaApplicazione,
                Versione = response.Versione,
                AmbienteId = response.AmbienteId,
                OffLine = response.OffLine,
                ConDisabilitati = response.ConDisabilitati,
                Contesto = response.Contesto,
                ParametriApplicazione = response.ParametroApplicazione,
                EventiClientApplicazione = response.EventoClientApplicazione,
                TracciamentoApplicazione = response.TracciamentoApplicazione,
                Referenti = response.LstReferenti,
                ParametriApplicazioneReport = response.parametriApplicazioneReport,
                CodiceFiscaleUtente = response.CodiceFiscaleUtente
            };
        }

        public static ApplicationParameterModel ToApplicationParameterModel(this ApplicationParameterData response)
        {
            return new ApplicationParameterModel
            {
                Codice = response.Codice,
                Valore = response.Valore,
                Descrizione = response.Descrizione,
                Note = response.Note,
                Obbligatorio = response.Obbligatorio,
                ParametroApplicazioneId = response.ParametroApplicazioneId,
                ApplicazioneId = response.ApplicazioneId
            };
        }

        public static ApplicationTipologyModel ToApplicationTipologyModel(this ApplicationTipologyData response)
        {
            return new ApplicationTipologyModel
            {
                Id = response.IdTipologiaApplicazione,
                TipologiaApplicazione = response.TipologiaApplicazione
            };
        }

        public static ApplicationVisibilityModel ToApplicationVisibilityModel(this ApplicationVisibilityData response)
        {
            return new ApplicationVisibilityModel
            {
                Id = response.IdVisibilitaApplicazione,
                VisibilitaApplicazione = response.VisibilitaApplicazione
            };
        }

        public static ClientEventApplicationModel ToClientEventApplicationModel(this ClientEventApplicationData response)
        {
            return new ClientEventApplicationModel
            {
                EventoID = response.EventoID,
                ApplicazioneId=response.ApplicazioneId,
                CodiceEvento = response.CodiceEvento,
                CodiceTipoEvento = response.CodiceTipoEvento,
                DescrizioneEvento = response.DescrizioneEvento,
                NoteEvento = response.NoteEvento,
                Notificabile = response.Notificabile,
                totParametriEvento = response.totParametriEvento,
                parametriEventoReport = response.parametriEventoReport,
                IsCommand = response.IsCommand,
                ParametroEvento  = response.ParametroEvento.Select(x => ToClientEventParameterModel(x)).ToList()
            };
        }

        public static ClientEventParameterModel ToClientEventParameterModel(this ClientEventParameterData response)
        {
            return new ClientEventParameterModel
            {
                Codice = response.Codice,
                Valore = response.Valore,
                Descrizione = response.Descrizione,
                Note = response.Note,
                Obbligatorio = response.Obbligatorio,
                ParametroEventoId = response.ParametroEventoId,
                EventoId = response.EventoId
            };
        }

        public static RoleModel ToRoleModel(this RoleData response)
        {
            return new RoleModel
            {
                Id = response.RuoloId,
                Nome = response.Nome,
                FineValidita = response.TS_FineValidita,
                //ListaReferenti = response.ListaReferenti.Select(x => new )
                ListaApplicazioni = response.ListaApplicazioni.Select(x => ToApplicationModel(x)).ToList(),
                Navigator = ToRoleNavigatorModel(response.Navigator)
            };
        }

        public static TipiReferentiModel ToTipiReferentiModel(this TipiReferentiData response)
        {
            return new TipiReferentiModel
            {
                Id = response.TipoReferenteID,
                Nome = response.Nome,
                Abbreviazione = response.Abbreviazione
            };
        }
        
        public static TrackingParameterModel ToTrackingParameterModel(this TrackingParameterData response)
        {
            return new TrackingParameterModel
            {
                Codice = response.Codice,
                Valore = response.Valore,
                Descrizione = response.Descrizione,
                Note = response.Note,
                Obbligatorio = response.Obbligatorio,
                ParametroTracciamentoId = response.ParametroTracciamentoId,
                TracciamentoId = response.TracciamentoId
            };
        }

        public static TrackingApplicationModel ToTrackingApplicationModel(this TrackingApplicationData response)
        {
            return new TrackingApplicationModel
            {
                TracciamentoId = response.TracciamentoId,
                ApplicazioneId = response.ApplicazioneId,
                CodiceTipoTracciamento = response.CodiceTipoTracciamento,
                CodiceTracciamento = response.CodiceTracciamento,
                DescrizioneTracciamento = response.DescrizioneTracciamento,
                NoteTracciamento = response.NoteTracciamento,
                NumeroParametriTracciamento = response.totParametriTracciamento,
                ParametriTracciamentoReport = response.parametriTracciamentoReport,
                ParametroTracciamento = response.ParametroTracciamento.Select(x => ToTrackingParameterModel(x)).ToList()
            };
        }

        public static RoleNavigatorModel ToRoleNavigatorModel(this RoleNavigatorData response)
        {
            return new RoleNavigatorModel
            {
                ApplicazioneId = response.ApplicazioneId,
                ReferenteId = response.ReferenteId
            };
        }



        public static ParameterModel ToParameterModel(this ParameterData response)
        {
            return new ParameterModel
            {
                Codice = response.Codice,
                Valore = response.Valore,
                Descrizione = response.Descrizione,
                Note = response.Note,
                Obbligatorio = response.Obbligatorio
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

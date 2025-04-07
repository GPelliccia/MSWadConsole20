using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using System.Runtime.Serialization;

namespace MSWadConsole20.Contract.BusinessModel
{
    public class ApplicationModel
    {
        public int Id { get; set; }
        public int LibreriaId { get; set; }
        public string CodiceWAD { get; set; }
        public string CodiceDimensions { get; set; }
        public string Descrizione{ get; set; }
        public DateTime DataInizioAttivazione { get; set; }
        public DateTime? DataFineAttivazione { get; set; }
        public bool FlagConsultazione { get; set; }
        public bool FlagGestione { get; set; }
        public bool FlagInternet { get; set; }
        public bool FlagIntranet { get; set; }
        public string Dominio { get; set; }
        public string Url { get; set; }
        public string NoteApplicazione { get; set; }
        public string Help64 { get; set; }
        public string PiattaformaApplicazione { get; set; }
        public string Versione { get; set; }
        public int? AmbienteId { get; set; }
        public bool OffLine { get; set; }
        public bool ConDisabilitati { get; set; }
        public int Contesto { get; set; }
        public List<ApplicationParameterData> ParametriApplicazione { get; set; }
        public List<ClientEventApplicationData> EventiClientApplicazione { get; set; }
        public List<TrackingApplicationData> TracciamentoApplicazione { get; set; }
        public List<ReferenteData> Referenti { get; set; }
        public string ParametriApplicazioneReport { get; set; }
        public string CodiceFiscaleUtente { get; set; }
    }
}

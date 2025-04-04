using System.Runtime.Serialization;
using MSWadConsole20.Repository.DataModel.Data;

namespace MSWadConsole20.Repository.DataModel
{
    public class ApplicationData
    {
        public int ApplicazioneId { get; set; }
        public int LibreriaApplicazioneId { get; set; }
        public string CodiceWAD { get; set; }
        public string CodiceDimensions { get; set; }
        public string DescrizioneApplicazione { get; set; }
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
        public List<ApplicationParameterData> ParametroApplicazione { get; set; }
        public List<ClientEventApplicationData> EventoClientApplicazione { get; set; }
        public List<TrackingApplicationData> TracciamentoApplicazione { get; set; }
        public List<ReferenteData> LstReferenti { get; set; }
        public string parametriApplicazioneReport { get; set; }
        public enum Ambiente
        {
            [EnumMember]
            INTERNET,
            [EnumMember]
            INTRANET
        }
        public string CodiceFiscaleUtente { get; set; }

    }
}

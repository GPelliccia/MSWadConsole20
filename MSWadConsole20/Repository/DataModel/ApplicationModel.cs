﻿using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel
{
    public class ApplicationModel
    {
        public int ApplicazioneId { get; set; }
        public int LibreriaApplicazioneId { get; set; }
        public String CodiceWAD { get; set; }
        public String CodiceDimensions { get; set; }
        public String DescrizioneApplicazione { get; set; }
        public DateTime DataInizioAttivazione { get; set; }
        public DateTime? DataFineAttivazione { get; set; }
        public bool FlagConsultazione { get; set; }
        public bool FlagGestione { get; set; }
        public bool FlagInternet { get; set; }
        public bool FlagIntranet { get; set; }
        public String Dominio { get; set; }
        public String Url { get; set; }
        public String NoteApplicazione { get; set; }
        public String Help64 { get; set; }
        public String PiattaformaApplicazione { get; set; }
        public String Versione { get; set; }
        public int? AmbienteId { get; set; }
        public bool OffLine { get; set; }
        public bool ConDisabilitati { get; set; }
        public int Contesto { get; set; }
        public ApplicationParameterModel[] ParametroApplicazione { get; set; }
        public ClientEventApplicationModel[] EventoClientApplicazione { get; set; }
        public TrackingApplicationModel[] TracciamentoApplicazione { get; set; }
        public ReferenteModel[] LstReferenti { get; set; }
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

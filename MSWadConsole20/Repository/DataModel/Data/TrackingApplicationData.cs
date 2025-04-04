using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel.Data
{
    public class TrackingApplicationData
    {

        public int TracciamentoId { get; set; }
        public int ApplicazioneId { get; set; }
        public string CodiceTracciamento { get; set; }
        public string CodiceTipoTracciamento { get; set; }
        public string DescrizioneTracciamento { get; set; }
        public string NoteTracciamento { get; set; }
        public int totParametriTracciamento { get; set; }
        public string parametriTracciamentoReport { get; set; }
        public TrackingParameterData[] ParametroTracciamento { get; set; }

    }
}

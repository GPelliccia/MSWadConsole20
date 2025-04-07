using MSWadConsole20.Repository.DataAccess.DataModel.Data;

namespace MSWadConsole20.Contract.BusinessModel
{
    public class TrackingApplicationModel
    {
        public int TracciamentoId { get; set; }
        public int ApplicazioneId { get; set; }
        public string CodiceTracciamento { get; set; }
        public string CodiceTipoTracciamento { get; set; }
        public string DescrizioneTracciamento { get; set; }
        public string NoteTracciamento { get; set; }
        public int NumeroParametriTracciamento { get; set; }
        public string ParametriTracciamentoReport { get; set; }
        public List<TrackingParameterModel> ParametroTracciamento { get; set; }
    }
}

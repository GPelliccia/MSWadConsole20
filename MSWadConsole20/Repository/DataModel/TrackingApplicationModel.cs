using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel
{
    public class TrackingApplicationModel
    {
      
        public int TracciamentoId { get; set; }      
        public int ApplicazioneId { get; set; }    
        public String CodiceTracciamento { get; set; }  
        public String CodiceTipoTracciamento { get; set; }   
        public String DescrizioneTracciamento { get; set; }   
        public String NoteTracciamento { get; set; }  
        public int totParametriTracciamento { get; set; }   
        public string parametriTracciamentoReport { get; set; }   
        public TrackingParameterModel[] ParametroTracciamento { get; set; }

    }
}

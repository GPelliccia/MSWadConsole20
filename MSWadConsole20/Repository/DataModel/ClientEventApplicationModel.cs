using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel
{
    public class ClientEventApplicationModel
    {
   
        public int EventoID { get; set; }     
        public int ApplicazioneID { get; set; }    
        public String CodiceTipoEvento { get; set; }     
        public String CodiceEvento { get; set; }   
        public String DescrizioneEvento { get; set; }     
        public String NoteEvento { get; set; }     
        public bool Notificabile { get; set; }     
        public int totParametriEvento { get; set; }    
        public string parametriEventoReport { get; set; }    
        public ClientEventParameterModel[] ParametroEvento { get; set; }
        public bool IsCommand { get; set; }

    }
}

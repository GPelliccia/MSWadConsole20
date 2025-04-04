using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel.Data
{
    public class ClientEventApplicationData
    {

        public int EventoID { get; set; }
        public int ApplicazioneID { get; set; }
        public string CodiceTipoEvento { get; set; }
        public string CodiceEvento { get; set; }
        public string DescrizioneEvento { get; set; }
        public string NoteEvento { get; set; }
        public bool Notificabile { get; set; }
        public int totParametriEvento { get; set; }
        public string parametriEventoReport { get; set; }
        public ClientEventParameterData[] ParametroEvento { get; set; }
        public bool IsCommand { get; set; }

    }
}

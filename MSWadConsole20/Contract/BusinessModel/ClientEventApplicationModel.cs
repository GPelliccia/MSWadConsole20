using MSWadConsole20.Repository.DataAccess.DataModel.Data;

namespace MSWadConsole20.Contract.BusinessModel
{
    public class ClientEventApplicationModel
    {
        public int EventoID { get; set; }
        public int ApplicazioneId { get; set; }
        public string CodiceTipoEvento { get; set; }
        public string CodiceEvento { get; set; }
        public string DescrizioneEvento { get; set; }
        public string NoteEvento { get; set; }
        public bool Notificabile { get; set; }
        public int totParametriEvento { get; set; }
        public string parametriEventoReport { get; set; }
        public List<ClientEventParameterModel> ParametroEvento { get; set; }
        public bool IsCommand { get; set; }
    }
}

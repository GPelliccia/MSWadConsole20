using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataAccess.DataModel.Data
{
    public class ClientEventParameterData : ParameterData
    {
        public int ParametroEventoId { get; set; }
        public int EventoId { get; set; }
    }
}

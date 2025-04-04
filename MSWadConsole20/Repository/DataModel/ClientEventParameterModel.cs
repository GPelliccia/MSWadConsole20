using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel
{
    public class ClientEventParameterModel : ParameterModel
    {
        public int ParametroEventoId { get; set; }
        public int EventoId { get; set; }
    }
}

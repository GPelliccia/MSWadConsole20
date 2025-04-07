using MSWadConsole20.Repository.DataAccess.DataModel.Data;

namespace MSWadConsole20.Contract.BusinessModel
{
    public class ClientEventParameterModel : ParameterModel
    {
        public int ParametroEventoId { get; set; }
        public int EventoId { get; set; }
    }
}

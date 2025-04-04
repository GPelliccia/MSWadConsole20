using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel
{
    public class TrackingParameterModel : ParameterModel
    {
        public int ParametroTracciamentoId { get; set; }
        public int TracciamentoId { get; set; }
    }
}

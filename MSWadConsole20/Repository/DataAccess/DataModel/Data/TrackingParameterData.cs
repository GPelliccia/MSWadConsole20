using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataAccess.DataModel.Data
{
    public class TrackingParameterData : ParameterData
    {
        public int ParametroTracciamentoId { get; set; }
        public int TracciamentoId { get; set; }
    }
}

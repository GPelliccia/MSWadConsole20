using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataAccess.DataModel.Data
{
    public class RoleData
    {
        public int RuoloId { get; set; }
        public string Nome { get; set; }
        public DateTime? TS_FineValidita { get; set; }
        public ReferenteData[] ListaReferenti { get; set; }
        public ApplicationData[] ListaApplicazioni { get; set; }
        public RoleNavigatorData Navigator { get; set; }
    }
}

using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel
{
    public class RoleModel
    {
        public int RuoloId { get; set; }
        public string Nome { get; set; }
        public DateTime? TS_FineValidita { get; set; }
        public ReferenteModel[] ListaReferenti { get; set; }
        public ApplicationModel[] ListaApplicazioni { get; set; }
        public RoleNavigatorModel Navigator { get; set; }
    }
}

using System.Runtime.Serialization;

namespace MSWadConsole20.Repository.DataModel
{
    public class WadApplicationModel : ApplicationModel
    {
        public int? TipologiaId { get; set; }
        public String TipologiaApplicazione { get; set; }
        public int? VisibilitaId { get; set; }
        public String VisibilitaApplicazione { get; set; }
        public RoleModel[] LstRuoli { get; set; }
        public String TitoloApplicazione { get; set; }
        public bool FlagGeneraCodWad { get; set; }
    }
}

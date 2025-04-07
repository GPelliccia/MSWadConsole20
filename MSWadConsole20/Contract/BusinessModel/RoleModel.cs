using MSWadConsole20.Repository.DataAccess.DataModel.Data;

namespace MSWadConsole20.Contract.BusinessModel
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? FineValidita { get; set; }
        public List<ReferentModel> ListaReferenti { get; set; }
        public List<ApplicationModel> ListaApplicazioni { get; set; }
        public RoleNavigatorModel Navigator { get; set; }
    }
}

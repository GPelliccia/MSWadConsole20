using MSWadConsole20.Contract.BusinessModel;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;

namespace MSWadConsole20.Contract
{
    public interface IReferentRepository
    {
        ServiceResponse<ReferentModel> GetReferent(ReferentRequest request);
        ServiceResponse<List<ReferentModel>> GetReferents(ReferentRequest request);
        ServiceResponse<List<TipoReferenteModel>> GetTypeReferents(TipiReferentiRequest request);
        ServiceResponse<int> InsertReferent(ReferentRequest request);
        ServiceResponse UpdateReferent(ReferentRequest request);
        ServiceResponse DeleteReferent(ReferentRequest request);
    }
}

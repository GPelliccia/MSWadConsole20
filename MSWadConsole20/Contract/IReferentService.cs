using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;

namespace MSWadConsole20.Contract
{
    public interface IReferentService
    {
        ServiceResponse<StoredResponse<ReferenteData>> GetReferent(ReferentRequest request);
        ServiceResponse<StoredResponse<List<ReferenteData>>> GetReferents(ReferentRequest request);
        ServiceResponse<StoredResponse<List<TipiReferentiData>>> GetTypeReferents(TipiReferentiRequest request);
        ServiceResponse<StoredResponse<int>> InsertReferent(ReferentRequest request);
        ServiceResponse<StoredResponse> UpdateReferent(ReferentRequest request);
        ServiceResponse<StoredResponse> DeleteReferent(ReferentRequest request);
    }
}

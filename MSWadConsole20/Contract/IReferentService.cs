using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel;

namespace MSWadConsole20.Contract
{
    public interface IReferentService
    {
        ServiceResponse<StoredData<ReferenteModel>> GetReferent(ReferentRequest request);

        ServiceResponse<StoredData<List<ReferenteModel>>> GetReferents(ReferentRequest request);
    }
}

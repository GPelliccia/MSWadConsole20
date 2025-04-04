using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataModel;
using MSWadConsole20.Repository.DataModel.Data;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel.Response;
using System.ComponentModel.Design;

namespace MSWadConsole20.Services
{
    public class ReferentService : IReferentService
    {
        private readonly IReferentRepository _repository;
        public ReferentService(IReferentRepository repository)
        {
            _repository = repository;
        }

        public ServiceResponse<StoredData<ReferenteData>> GetReferent(ReferentRequest request) => _repository.GetReferent(request);

        public ServiceResponse<StoredData<List<ReferenteData>>> GetReferents(ReferentRequest request) => _repository.GetReferents(request);
    }
}

using Azure.Core;
using MSWadConsole20.Contract;
using MSWadConsole20.Contract.BusinessModel;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;
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

        public ServiceResponse<ReferentModel> GetReferent(ReferentRequest request) => _repository.GetReferent(request);
        public ServiceResponse<List<ReferentModel>> GetReferents(ReferentRequest request) => _repository.GetReferents(request);
        public ServiceResponse<List<TipoReferenteModel>> GetTypeReferents(TipiReferentiRequest request) => _repository.GetTypeReferents(request);
        public ServiceResponse<int> InsertReferent(ReferentRequest request) => _repository.InsertReferent(request);
        public ServiceResponse UpdateReferent(ReferentRequest request) => _repository.UpdateReferent(request);
        public ServiceResponse DeleteReferent(ReferentRequest request) => _repository.DeleteReferent(request);
    }
}

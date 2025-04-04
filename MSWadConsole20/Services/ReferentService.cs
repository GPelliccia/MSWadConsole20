using Azure.Core;
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
        public ServiceResponse<StoredData<List<TipiReferenti>>> GetTypeReferents(TipiReferentiRequest request) => _repository.GetTypeReferents(request);
        public ServiceResponse<StoredData<int>> InsertReferent(ReferentRequest request) => _repository.InsertReferent(request);
        public ServiceResponse<StoredData> UpdateReferent(ReferentRequest request) => _repository.AggiornaReferente(request);
        public ServiceResponse<StoredData> DeleteReferent(ReferentRequest request) => _repository.DeleteReferent(request);
    }
}

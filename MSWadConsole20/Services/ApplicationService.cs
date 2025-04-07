using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataModel;
using MSWadConsole20.Repository.DataModel.Data;
using MSWadConsole20.Repository.DataModel.Request.ApplicationModel;
using MSWadConsole20.Repository.DataModel.Response;

namespace MSWadConsole20.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repository;
        public ApplicationService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public ServiceResponse<WadApplicationData> GetApplication(ApplicationModelRequest request) => _repository.GetApplication(request);
        public ServiceResponse<List<WadApplicationData>> GetApplications(ApplicationModelRequest request) => _repository.GetApplications(request);
        public ServiceResponse<ApplicationData> GetApplicazioneReport(ApplicationModelRequest request) => _repository.GetApplicazioneReport(request);
        public ServiceResponse<List<ReferenteData>> GetApplicationReferents(ApplicationModelRequest request) => _repository.GetApplicationReferents(request);
        public ServiceResponse<List<ApplicationTipologyData>> GetTipologieApplicazione() => _repository.GetTipologieApplicazione();
        public ServiceResponse<List<ApplicationVisibilityData>> GetVisibilitaApplicazione() => _repository.GetVisibilitaApplicazione();
    }
}

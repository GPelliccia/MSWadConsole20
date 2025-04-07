using MSWadConsole20.Repository.DataModel;
using MSWadConsole20.Repository.DataModel.Data;
using MSWadConsole20.Repository.DataModel.Request.ApplicationModel;
using MSWadConsole20.Repository.DataModel.Response;

namespace MSWadConsole20.Contract
{
    public interface IApplicationService
    {
        public ServiceResponse<WadApplicationData> GetApplication(ApplicationModelRequest request);
        public ServiceResponse<List<WadApplicationData>> GetApplications(ApplicationModelRequest request);
        public ServiceResponse<List<ReferenteData>> GetApplicationReferents(ApplicationModelRequest request);
        public ServiceResponse<List<ApplicationTipologyData>> GetTipologieApplicazione();
        public ServiceResponse<List<ApplicationVisibilityData>> GetVisibilitaApplicazione();
        public ServiceResponse<ApplicationData> GetApplicazioneReport(ApplicationModelRequest request);
    }
}

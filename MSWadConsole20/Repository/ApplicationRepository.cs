using Azure.Core;
using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess;
using MSWadConsole20.Repository.DataModel;
using MSWadConsole20.Repository.DataModel.Data;
using MSWadConsole20.Repository.DataModel.Request.ApplicationModel;
using MSWadConsole20.Repository.DataModel.Response;

namespace MSWadConsole20.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApplicationRepository> _logger;
        private readonly ApplicationDataAccess _dataAccess;

        public ApplicationRepository(IConfiguration configuration, ILogger<ApplicationRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _dataAccess = new ApplicationDataAccess(_configuration["DB_CONNECTION"]);
        }

        public ServiceResponse<WadApplicationData> GetApplication(ApplicationModelRequest request)
        {
            return ExecuteDataAccessMethod<WadApplicationData, ApplicationModelRequest>(_dataAccess.GetApplication, request);
        }

        public ServiceResponse<List<WadApplicationData>> GetApplications(ApplicationModelRequest request)
        {
            return ExecuteDataAccessMethod<List<WadApplicationData>, ApplicationModelRequest>(_dataAccess.GetApplications, request);
        }

        public ServiceResponse<ApplicationData> GetApplicazioneReport(ApplicationModelRequest request)
        {
            return ExecuteDataAccessMethod<ApplicationData, ApplicationModelRequest>(_dataAccess.GetApplicazioneReport, request);
        }

        public ServiceResponse<List<ReferenteData>> GetApplicationReferents(ApplicationModelRequest request)
        {
            return ExecuteDataAccessMethod<List<ReferenteData>, ApplicationModelRequest>(_dataAccess.GetApplicationReferents, request);
        }

        public ServiceResponse<List<ApplicationTipologyData>> GetTipologieApplicazione()
        {
            return ExecuteDataAccessMethod<List<ApplicationTipologyData>>(_dataAccess.GetTipologieApplicazione);
        }

        public ServiceResponse<List<ApplicationVisibilityData>> GetVisibilitaApplicazione()
        {
            return ExecuteDataAccessMethod<List<ApplicationVisibilityData>>(_dataAccess.GetVisibilitaApplicazione);
        }


        private ServiceResponse<T> ExecuteDataAccessMethod<T,K>(Func<K, StoredData<T>> method, K request)
        { 
            var response = new ServiceResponse<T>();
            try
            {
                var result = method(request);
                response.SetServiceResponseFromStoredData(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.SetErrorOnCompletOperation();
            }
            return response;
        }


        private ServiceResponse<T> ExecuteDataAccessMethod<T>(Func<StoredData<T>> method)
        {
            var response = new ServiceResponse<T>();
            try
            {
                var result = method();
                response.SetServiceResponseFromStoredData(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.SetErrorOnCompletOperation();
            }
            return response;
        }
    }
}

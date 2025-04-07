using Azure.Core;
using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request.ApplicationModel;
using MSWadConsole20.Repository.DataModel;

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
            var response = new ServiceResponse<WadApplicationData>();
            try
            {
                var result = _dataAccess.GetApplication(request);
                response.SetServiceResponseFromStoredData(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.SetErrorOnCompletOperation();
            }
            return response;


        }

        public ServiceResponse<List<WadApplicationData>> GetApplications(ApplicationModelRequest request)
        {

            var response = new ServiceResponse<List<WadApplicationData>>();
            try
            {
                var result = _dataAccess.GetApplications(request);
                response.SetServiceResponseFromStoredData(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.SetErrorOnCompletOperation();
            }
            return response;
        }

        public ServiceResponse<ApplicationData> GetApplicazioneReport(ApplicationModelRequest request)
        {
            var response = new ServiceResponse<ApplicationData>();
            try
            {
                var result = _dataAccess.GetApplicazioneReport(request);
                response.SetServiceResponseFromStoredData(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.SetErrorOnCompletOperation();
            }
            return response;        
        }

        public ServiceResponse<List<ReferenteData>> GetApplicationReferents(ApplicationModelRequest request)
        {
            var response = new ServiceResponse<List<ReferenteData>>();
            try
            {
                var result = _dataAccess.GetApplicationReferents(request);
                response.SetServiceResponseFromStoredData(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.SetErrorOnCompletOperation();
            }
            return response;
        }

        public ServiceResponse<List<ApplicationTipologyData>> GetTipologieApplicazione()
        {
            var response = new ServiceResponse<List<ApplicationTipologyData>>();
            try
            {
                var result = _dataAccess.GetTipologieApplicazione();
                response.SetServiceResponseFromStoredData(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.SetErrorOnCompletOperation();
            }
            return response;
        }

        public ServiceResponse<List<ApplicationVisibilityData>> GetVisibilitaApplicazione()
        {
            var response = new ServiceResponse<List<ApplicationVisibilityData>>();
            try
            {
                var result = _dataAccess.GetVisibilitaApplicazione();
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

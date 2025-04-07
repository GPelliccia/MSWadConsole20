using MSWadConsole20.Contract;
using MSWadConsole20.Contract.BusinessModel;
using MSWadConsole20.Repository.DataAccess;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;

namespace MSWadConsole20.Repository
{
    public class ReferentRepository : IReferentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ReferentRepository> _logger;
        private readonly ReferentDataAccess _dataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferentRepository" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public ReferentRepository(IConfiguration configuration, ILogger<ReferentRepository> logger, ReferentDataAccess dataAccess)
        {
            _configuration = configuration;
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public ServiceResponse<ReferentModel> GetReferent(ReferentRequest request)
        {
            var response = new ServiceResponse<ReferentModel>();
            try
            {
                var storedResponse = _dataAccess.GetReferent(request);
                var referentModel = storedResponse?.Data?.ToReferentModel();
                response.Data = referentModel;
                response.Success = true;
                response.ErrorMessage = storedResponse?.ErrorMessage;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il referente");
                response.Success = false;
                response.UserMessage = response.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse<List<ReferentModel>> GetReferents(ReferentRequest request)
        {
            var response = new ServiceResponse<List<ReferentModel>>();
            try
            {
                var storedResponse = _dataAccess?.GetReferents(request);
                var listReferent = storedResponse?.Data?.Select(s => s.ToReferentModel()).ToList();
                response.Data = listReferent;
                response.Success = true;
                response.ErrorMessage = storedResponse?.ErrorMessage;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare i referenti");
                response.Success = false;
                response.UserMessage = response.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse<List<TipoReferenteModel>> GetTypeReferents(TipiReferentiRequest request)
        {
            var response = new ServiceResponse<List<TipoReferenteModel>>();
            try
            {
                var storedResponse = _dataAccess?.GetTypeReferents(request);
                response.Data = storedResponse?.Data?.Select(s => s.ToTipiReferentiModel()).ToList();
                response.Success = true;
                response.ErrorMessage = storedResponse?.ErrorMessage;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare i tipi dei referenti");
                response.Success = false;
                response.UserMessage = response.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse<int> InsertReferent(ReferentRequest request)
        {
            var response = new ServiceResponse<int>();
            try
            {
                var storedResponse = _dataAccess.InsertReferent(request);
                response = storedResponse.ToServiceResponse();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella creazione del referente");
                response.Success = false;
                response.UserMessage = response.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse UpdateReferent(ReferentRequest request)
        {
            var response = new ServiceResponse();
            try
            {
                var storedResponse = _dataAccess.UpdateReferent(request);
                response = storedResponse.ToServiceResponse() ?? new ServiceResponse();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel modificare il referente");
                response.Success = false;
                response.UserMessage = response.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse DeleteReferent(ReferentRequest request)
        {
            var response = new ServiceResponse();
            try
            {
                var storedResponse = _dataAccess.ChiudiReferente(request);
                response = storedResponse.ToServiceResponse() ?? new ServiceResponse();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel disattivare il referente");
                response.Success = false;
                response.UserMessage = response.ErrorMessage;
            }
            return response;
        }
    }
}

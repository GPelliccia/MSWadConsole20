using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess;
using MSWadConsole20.Repository.DataModel;
using MSWadConsole20.Repository.DataModel.Data;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel.Response;

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
        public ReferentRepository(IConfiguration configuration, ILogger<ReferentRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _dataAccess = new ReferentDataAccess(_configuration["DB_CONNECTION"]);
        }

        public ServiceResponse<StoredData<ReferenteData>> GetReferent(ReferentRequest request)
        {
            var response = new ServiceResponse<StoredData<ReferenteData>>();
            try
            {
                response.Data = _dataAccess.GetReferent(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il referente");
                response.Success = false;
                response.UserMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<StoredData<List<ReferenteData>>> GetReferents(ReferentRequest request)
        {
            var response = new ServiceResponse<StoredData<List<ReferenteData>>>();
            try
            {
                response.Data = _dataAccess.GetReferents(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare i referenti");
                response.Success = false;
                response.UserMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<StoredData<List<TipiReferenti>>> GetTypeReferents(TipiReferentiRequest request)
        {
            var response = new ServiceResponse<StoredData<List<TipiReferenti>>>();
            try
            {
                response.Data = _dataAccess.GetTypeReferents(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare i tipi dei referenti");
                response.Success = false;
                response.UserMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<StoredData<int>> InsertReferent(ReferentRequest request)
        {
            var response = new ServiceResponse<StoredData<int>>();
            try
            {
                response.Data = _dataAccess.InsertReferent(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.Success = false;
                response.UserMessage = response.Data?.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse<StoredData> AggiornaReferente(ReferentRequest request)
        {
            var response = new ServiceResponse<StoredData>();
            try
            {
                response.Data = _dataAccess.AggiornaReferente(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.Success = false;
                response.UserMessage = response.Data?.ErrorMessage;
            }
            return response;
        }
    }
}

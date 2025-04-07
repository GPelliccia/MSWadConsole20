using MSWadConsole20.Contract;
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
        public ReferentRepository(IConfiguration configuration, ILogger<ReferentRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _dataAccess = new ReferentDataAccess(_configuration["DB_CONNECTION"]);
        }

        public ServiceResponse<StoredResponse<ReferenteData>> GetReferent(ReferentRequest request)
        {
            var response = new ServiceResponse<StoredResponse<ReferenteData>>();
            try
            {
                response.Data = _dataAccess.GetReferent(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il referente");
                response.Success = false;
                response.UserMessage = response.Data?.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse<StoredResponse<List<ReferenteData>>> GetReferents(ReferentRequest request)
        {
            var response = new ServiceResponse<StoredResponse<List<ReferenteData>>>();
            try
            {
                response.Data = _dataAccess.GetReferents(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare i referenti");
                response.Success = false;
                response.UserMessage = response.Data?.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse<StoredResponse<List<TipiReferentiData>>> GetTypeReferents(TipiReferentiRequest request)
        {
            var response = new ServiceResponse<StoredResponse<List<TipiReferentiData>>>();
            try
            {
                response.Data = _dataAccess.GetTypeReferents(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare i tipi dei referenti");
                response.Success = false;
                response.UserMessage = response.Data?.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse<StoredResponse<int>> InsertReferent(ReferentRequest request)
        {
            var response = new ServiceResponse<StoredResponse<int>>();
            try
            {
                response.Data = _dataAccess.InsertReferent(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella creazione del referente");
                response.Success = false;
                response.UserMessage = response.Data?.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse<StoredResponse> UpdateReferent(ReferentRequest request)
        {
            var response = new ServiceResponse<StoredResponse>();
            try
            {
                response.Data = _dataAccess.UpdateReferent(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel modificare il referente");
                response.Success = false;
                response.UserMessage = response.Data?.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse<StoredResponse> DeleteReferent(ReferentRequest request)
        {
            var response = new ServiceResponse<StoredResponse>();
            try
            {
                response.Data = _dataAccess.ChiudiReferente(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel disattivare il referente");
                response.Success = false;
                response.UserMessage = response.Data?.ErrorMessage;
            }
            return response;
        }
    }
}

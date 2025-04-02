using Microsoft.EntityFrameworkCore;
using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel;

namespace MSWadConsole20.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDbContextFactory<ConfigurationDataAccess> _serviceDataAccess;
        private readonly ILogger<ConfigurationRepository> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationRepository" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceDataAccess">The mia data access.</param>
        public ConfigurationRepository(IConfiguration configuration, ILogger<ConfigurationRepository> logger, IDbContextFactory<ConfigurationDataAccess> serviceDataAccess)
        {
            _configuration = configuration;
            _logger = logger;
            _serviceDataAccess = serviceDataAccess;
        }

        public ServiceResponse<List<AmbienteData>?> GetAmbiente()
        {
            ServiceResponse<List<AmbienteData>?> response = new();

            try
            {
                using (var context = _serviceDataAccess.CreateDbContext())
                {
                    response.Data = context.GetAmbiente();
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.Success = false;
                response.ErrorMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<LibraryData?> GetLibrary(LibraryRequest request)
        {
            ServiceResponse<LibraryData?> response = new();

            try
            {
                using (var context = _serviceDataAccess.CreateDbContext())
                {
                    response.Data = context.GetLibrary(request);
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.Success = false;
                response.ErrorMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<List<LibraryData>?> GetLibraries(LibraryRequest request)
        {
            ServiceResponse<List<LibraryData>?> response = new();

            try
            {
                using (var context = _serviceDataAccess.CreateDbContext())
                {
                    response.Data = context.GetLibraries(request);
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.Success = false;
                response.ErrorMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }
    }
}

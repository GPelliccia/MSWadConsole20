using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MSWadConsole20.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ConfigurationRepository> _logger;
        private readonly ConfigurationDataAccess _dataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationRepository" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public ConfigurationRepository(IConfiguration configuration, ILogger<ConfigurationRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _dataAccess = new ConfigurationDataAccess(_configuration["DB_CONNECTION"]);
        }

        public ServiceResponse<List<AmbienteData>?> GetAmbiente()
        {
            var response = new ServiceResponse<List<AmbienteData>?>();
            try
            {
                response.Data = _dataAccess.GetAmbiente();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.Success = false;
                response.UserMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<LibraryData?> GetLibrary(LibraryRequest request)
        {
            var response = new ServiceResponse<LibraryData?>();
            try
            {
                response.Data = _dataAccess.GetLibrary(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.Success = false;
                response.UserMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<List<LibraryData>?> GetLibraries(LibraryRequest request)
        {
            var response = new ServiceResponse<List<LibraryData>?>();
            try
            {
                response.Data = _dataAccess.GetLibraries(request);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare il parametro di attività del servizio");
                response.Success = false;
                response.UserMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<StoredData<int>> InsertLibrary(LibraryRequest request)
        {
            var response = new ServiceResponse<StoredData<int>>();
            try
            {
                response.Data = _dataAccess.InsertLibrary(request);
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

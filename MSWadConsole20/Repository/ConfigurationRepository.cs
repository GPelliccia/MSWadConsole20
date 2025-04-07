using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;
using MSWadConsole20.Contract.BusinessModel;

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
        public ConfigurationRepository(IConfiguration configuration, ILogger<ConfigurationRepository> logger, ConfigurationDataAccess dataAccess)
        {
            _configuration = configuration;
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public ServiceResponse<List<AmbienteModel>?> GetAmbiente()
        {
            var response = new ServiceResponse<List<AmbienteModel>?>();
            try
            {
                response.Data = _dataAccess.GetAmbiente()?.Select(s => s.ToAmbienteModel()).ToList();
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

        public ServiceResponse<LibraryModel?> GetLibrary(LibraryRequest request)
        {
            var response = new ServiceResponse<LibraryModel?>();
            try
            {
                response.Data = _dataAccess?.GetLibrary(request)?.ToLibraryModel();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare la libreria");
                response.Success = false;
                response.UserMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<List<LibraryModel>?> GetLibraries(LibraryRequest request)
        {
            var response = new ServiceResponse<List<LibraryModel>?>();
            try
            {
                response.Data = _dataAccess?.GetLibraries(request)?.Select(s => s.ToLibraryModel()).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel recuperare le librerie");
                response.Success = false;
                response.UserMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse<int> InsertLibrary(LibraryRequest request)
        {
            var response = new ServiceResponse<int>();
            try
            {
                var storedResponse = _dataAccess.InsertLibrary(request);
                response = storedResponse.ToServiceResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella creazione della libreria");
                response.Success = false;
                response.UserMessage = "Non è possibile completare l'operazione.";
            }
            return response;
        }

        public ServiceResponse UpdateLibrary(LibraryRequest request)
        {
            var response = new ServiceResponse();
            try
            {
                var storedResponse = _dataAccess.UpdateLibrary(request);
                response = storedResponse?.ToServiceResponse() ?? new ServiceResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella modifica della libreria");
                response.Success = false;
                response.UserMessage = response.ErrorMessage;
            }
            return response;
        }

        public ServiceResponse DeleteLibrary(LibraryRequest request)
        {
            var response = new ServiceResponse();
            try
            {
                var storedResponse = _dataAccess.DeleteLibrary(request);
                response = storedResponse?.ToServiceResponse() ?? new ServiceResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nel disattivare la libreria");
                response.Success = false;
                response.UserMessage = response.ErrorMessage;
            }
            return response;
        }
    }
}

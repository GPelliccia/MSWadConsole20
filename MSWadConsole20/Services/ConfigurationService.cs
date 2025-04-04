﻿using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel;
using MSWadConsole20.Repository.DataModel.Data;

namespace MSWadConsole20.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _repository;
        public ConfigurationService(IConfigurationRepository repository)
        {
            _repository = repository;
        }

        public ServiceResponse<List<AmbienteData>?> GetAmbiente() => _repository.GetAmbiente();

        public ServiceResponse<LibraryData?> GetLibrary(LibraryRequest request) => _repository.GetLibrary(request);

        public ServiceResponse<List<LibraryData>?> GetLibraries(LibraryRequest request) => _repository.GetLibraries(request);

        public ServiceResponse<StoredData<int>> InsertLibrary(LibraryRequest request) => _repository.InsertLibrary(request);

        public ServiceResponse<StoredData> UpdateLibrary(LibraryRequest request) => _repository.UpdateLibrary(request);
        public ServiceResponse<StoredData> DeleteLibrary(LibraryRequest request) => _repository.DeleteLibrary(request);

    }
}

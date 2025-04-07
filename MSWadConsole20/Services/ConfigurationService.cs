using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;

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

        public ServiceResponse<int> InsertLibrary(LibraryRequest request) => _repository.InsertLibrary(request);

        public ServiceResponse<StoredResponse> UpdateLibrary(LibraryRequest request) => _repository.UpdateLibrary(request);
        public ServiceResponse<StoredResponse> DeleteLibrary(LibraryRequest request) => _repository.DeleteLibrary(request);

    }
}

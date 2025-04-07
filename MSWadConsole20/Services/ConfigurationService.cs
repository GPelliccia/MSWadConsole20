using MSWadConsole20.Contract;
using MSWadConsole20.Contract.BusinessModel;
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

        public ServiceResponse<List<AmbienteModel>?> GetAmbiente() => _repository.GetAmbiente();

        public ServiceResponse<LibraryModel?> GetLibrary(LibraryRequest request) => _repository.GetLibrary(request);

        public ServiceResponse<List<LibraryModel>?> GetLibraries(LibraryRequest request) => _repository.GetLibraries(request);

        public ServiceResponse<int> InsertLibrary(LibraryRequest request) => _repository.InsertLibrary(request);

        public ServiceResponse UpdateLibrary(LibraryRequest request) => _repository.UpdateLibrary(request);
        public ServiceResponse DeleteLibrary(LibraryRequest request) => _repository.DeleteLibrary(request);

    }
}

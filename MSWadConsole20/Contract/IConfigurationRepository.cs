using MSWadConsole20.Contract.BusinessModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;

namespace MSWadConsole20.Contract
{
    public interface IConfigurationRepository
    {
        ServiceResponse<List<AmbienteModel>?> GetAmbiente();

        ServiceResponse<LibraryModel?> GetLibrary(LibraryRequest request);

        ServiceResponse<List<LibraryModel>?> GetLibraries(LibraryRequest request);

        ServiceResponse<int> InsertLibrary(LibraryRequest request);

        ServiceResponse UpdateLibrary(LibraryRequest request);

        ServiceResponse DeleteLibrary(LibraryRequest request);

    }
}

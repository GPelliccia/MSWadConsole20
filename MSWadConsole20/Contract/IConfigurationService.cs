using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;

namespace MSWadConsole20.Contract
{
    public interface IConfigurationService
    {
        ServiceResponse<List<AmbienteData>?> GetAmbiente();
        ServiceResponse<LibraryData?> GetLibrary(LibraryRequest request);
        //ConfigurationResponse GetLibraries(ConfigurationRequest request)
        ServiceResponse<List<LibraryData>?> GetLibraries(LibraryRequest request);

        ServiceResponse<int> InsertLibrary(LibraryRequest request);

        ServiceResponse<StoredResponse> UpdateLibrary(LibraryRequest request);
        ServiceResponse<StoredResponse> DeleteLibrary(LibraryRequest request);

    }
}

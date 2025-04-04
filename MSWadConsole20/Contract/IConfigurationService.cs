using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel.Data;

namespace MSWadConsole20.Contract
{
    public interface IConfigurationService
    {
        ServiceResponse<List<AmbienteData>?> GetAmbiente();
        ServiceResponse<LibraryData?> GetLibrary(LibraryRequest request);
        //ConfigurationResponse GetLibraries(ConfigurationRequest request)
        ServiceResponse<List<LibraryData>?> GetLibraries(LibraryRequest request);

        ServiceResponse<StoredData<int>> InsertLibrary(LibraryRequest request);

        ServiceResponse<StoredData> UpdateLibrary(LibraryRequest request);
        ServiceResponse<StoredData> DeleteLibrary(LibraryRequest request);

    }
}

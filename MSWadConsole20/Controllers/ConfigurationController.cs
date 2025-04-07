using Microsoft.AspNetCore.Mvc;
using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess.DataModel;
using MSWadConsole20.Repository.DataAccess.DataModel.Data;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;

namespace MSWadConsole20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {

        private readonly IConfigurationService _ConfigurationService;

        public ConfigurationController(IConfigurationService ConfigurationService)
        {
            _ConfigurationService = ConfigurationService;
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ConfigurationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<List<AmbienteData>?>> GetAmbiente(ConfigurationRequest req)
        {
            try
            {
                var response = _ConfigurationService.GetAmbiente();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ConfigurationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<LibraryData?>> GetLibrary(LibraryRequest request)
        {
            try
            {
                var response = _ConfigurationService.GetLibrary(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ConfigurationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<List<LibraryData>?>> GetLibraries(LibraryRequest request)
        {
            try
            {
                var response = _ConfigurationService.GetLibraries(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ConfigurationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<int>> InsertLibrary(LibraryRequest request)
        {
            try
            {
                var response = _ConfigurationService.InsertLibrary(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }


        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ConfigurationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<StoredResponse>> UpdateLibrary(LibraryRequest request)
        {
            try
            {
                var response = _ConfigurationService.UpdateLibrary(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }


        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ConfigurationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<StoredResponse>> DeleteLibrary(LibraryRequest request)
        {
            try
            {
                var response = _ConfigurationService.DeleteLibrary(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }


        }
    }
}

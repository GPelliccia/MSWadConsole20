using Microsoft.AspNetCore.Mvc;
using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel;

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
    }
}

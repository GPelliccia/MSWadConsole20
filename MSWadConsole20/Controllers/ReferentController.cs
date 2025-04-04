using Microsoft.AspNetCore.Mvc;
using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel;
using MSWadConsole20.Services;
using MSWadConsole20.Repository.DataModel.Data;

namespace MSWadConsole20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferentController : ControllerBase
    {

        private readonly IReferentService _ReferentService;

        public ReferentController(IReferentService ReferentService)
        {
            _ReferentService = ReferentService;
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ConfigurationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<StoredData<ReferenteData>>> GetReferent(ReferentRequest request)
        {
            try
            {
                var response = _ReferentService.GetReferent(request);
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
        public ActionResult<ServiceResponse<StoredData<List<ReferenteData>>>> GetReferents(ReferentRequest request)
        {
            try
            {
                var response = _ReferentService.GetReferents(request);
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
        public ActionResult<ServiceResponse<StoredData<List<TipiReferenti>>>> GetTypeReferents(TipiReferentiRequest request)
        {
            try
            {
                var response = _ReferentService.GetTypeReferents(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }

    }
}

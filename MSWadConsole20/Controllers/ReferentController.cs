using Microsoft.AspNetCore.Mvc;
using MSWadConsole20.Contract;
using MSWadConsole20.Repository.DataAccess.DataModel.Request;
using MSWadConsole20.Repository.DataAccess.DataModel.Response;
using MSWadConsole20.Contract.BusinessModel;

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
        public ActionResult<ServiceResponse<ReferentModel>> GetReferent(ReferentRequest request)
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
        public ActionResult<ServiceResponse<List<ReferentModel>>> GetReferents(ReferentRequest request)
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
        public ActionResult<ServiceResponse<List<TipoReferenteModel>>> GetTypeReferents(TipiReferentiRequest request)
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

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ConfigurationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<ServiceResponse<int>> InsertReferent(ReferentRequest request)
        {
            try
            {
                var response = _ReferentService.InsertReferent(request);
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
        public ActionResult<ServiceResponse> UpdateReferent(ReferentRequest request)
        {
            try
            {
                var response = _ReferentService.UpdateReferent(request);
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
        public ActionResult<ServiceResponse> DeleteReferent(ReferentRequest request)
        {
            try
            {
                var response = _ReferentService.DeleteReferent(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, null, 500);
            }
        }

    }
}

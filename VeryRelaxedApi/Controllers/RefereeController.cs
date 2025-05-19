using Microsoft.AspNetCore.Mvc;
using VeryRelaxedApi.Models;
using VeryRelaxedApi.BusinessLogic;
using VeryRelaxedApi.DTO;

namespace VeryRelaxedApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RefereeController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IRefereeBusinessLogic _refereeBusinessLogic;

        // Inject logger and business logic in the constructor
        public RefereeController(ILogger<PlayerController> logger, IRefereeBusinessLogic refereeBusinessLogic)
        {
            _logger = logger;
            _refereeBusinessLogic = refereeBusinessLogic;
        }

        // Existing GET method for footballer
        [HttpGet("coaches")]
        public async Task<IActionResult> GetAllReferees()
        {
            try
            {
                var result = await _refereeBusinessLogic.getAllReferees();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting coaches");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addCoach")]
        public async Task<IActionResult> AddCoach([FromBody]RefereeDto referee)
        {
            try
            {
                var result = await _refereeBusinessLogic.AddReferee(referee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding coach");
                return BadRequest(ex.Message);
            }
        }
    }
}

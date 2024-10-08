using Microsoft.AspNetCore.Mvc;
using VeryRelaxedApi.Models;
using VeryRelaxedApi.BusinessLogic;

namespace VeryRelaxedApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoachController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly ICoachBusinessLogic _coachBusinessLogic;

        // Inject logger and business logic in the constructor
        public CoachController(ILogger<PlayerController> logger, ICoachBusinessLogic coachBusinessLogic)
        {
            _logger = logger;
            _coachBusinessLogic = coachBusinessLogic;
        }

        // Existing GET method for footballer
        [HttpGet("coaches")]
        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                var result = await _coachBusinessLogic.GetAllCoaches();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting players");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addCoach")]
        public async Task<IActionResult> AddCoach(string name, string nationality, string styleDescription, string age)
        {
            try
            {
                await _coachBusinessLogic.AddCoach(name, nationality, styleDescription, age);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldnt add coach");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("removeCoach")]
        public async Task<IActionResult> RemoveCoach(Guid id)
        {
            try
            {
                await _coachBusinessLogic.RemoveCoach(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Couldnt delete coach");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("searchCoach")]
        public async Task<IActionResult> SearchCoach(string searchword)
        {
            try
            {
                var result = await _coachBusinessLogic.SearchCoachToList(searchword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Coach {searchword}");
                return BadRequest(ex.Message);
            }
        }

    }
}

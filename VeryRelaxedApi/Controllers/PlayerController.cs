using Microsoft.AspNetCore.Mvc;
using VeryRelaxedApi.Models;
using VeryRelaxedApi.BusinessLogic;

namespace VeryRelaxedApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerBusinessLogic _playerBusinessLogic;

        // Inject logger and business logic in the constructor
        public PlayerController(ILogger<PlayerController> logger, IPlayerBusinessLogic playerBusinessLogic)
        {
            _logger = logger;
            _playerBusinessLogic = playerBusinessLogic;
        }

        // Existing GET method for footballer
        [HttpGet("footballers")]
        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                var result = await _playerBusinessLogic.GetAllPlayers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting players");
                return BadRequest(ex.Message);
            }
        }

        // New method to change player's name
        [HttpPut("change-name")]
        public async Task<IActionResult> ChangePlayerName([FromQuery] string oldName, [FromQuery] string newName)
        {
            try
            {
                // Call the business logic to change the player's name
                await _playerBusinessLogic.ChangePlayerNameAsync(oldName, newName);
                return Ok($"Player name changed from {oldName} to {newName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing player name");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register-player")]
        public async Task<IActionResult> RegisterPlayer([FromQuery] string name, [FromQuery] string age, [FromQuery] string nationality, [FromQuery] string prefferedFoot)
        {
            try
            {
                await _playerBusinessLogic.RegisterPlayer(name, age, nationality, prefferedFoot);
                return Ok($"Player registered with name {name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering player");
                return BadRequest(ex.Message);
            }
        }
    }
}

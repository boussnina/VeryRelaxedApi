using VeryRelaxedApi.DTO;
using VeryRelaxedApi.Models;

namespace VeryRelaxedApi.BusinessLogic
{
    public interface IPlayerBusinessLogic
    {
        Task<List<Footballer>> GetAllPlayers();
        Task<Guid> GetPlayerGuidByPlayernameAsync(string playerName);

        Task ChangePlayerNameAsync(string oldName, string newName);

        Task RegisterPlayer(PlayerDto player);
    }
}

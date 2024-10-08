using VeryRelaxedApi.Models;

namespace VeryRelaxedApi.Repository
{
    public interface IPlayerRepository
    {
        Task<List<Footballer>> GetAllPlayers();
        Task<Guid> GetPlayerGuidByPlayernameAsync(string playerName);

        Task ChangePlayerNameAsync(string oldName, string newName);

        Task RegisterPlayer(string name, string age, string preferredFoot, string nationality);
    }
}

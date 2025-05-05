using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VeryRelaxedApi.BusinessLogic;
using VeryRelaxedApi.DTO;
using VeryRelaxedApi.Models;
using VeryRelaxedApi.Repository;

namespace VeryRelaxedApi.BusinessLogic
{

    public class PlayerBusinessLogic : IPlayerBusinessLogic
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerBusinessLogic( IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }


        public async Task<List<Footballer>> GetAllPlayers()
            {
                var result = await _playerRepository.GetAllPlayers();
                return result;
            }
            public async Task<Guid> GetPlayerGuidByPlayernameAsync(string name)
        {
            await Task.Delay(100);
            return Guid.NewGuid();
        }

        public async Task ChangePlayerNameAsync(string oldName, string newName)
        {
                // Find the player by their old name
            await _playerRepository.ChangePlayerNameAsync(oldName, newName);

        }

        public async Task RegisterPlayer(PlayerDto player)
        {
            await _playerRepository.RegisterPlayer(player);

            return;
        }
    }
}
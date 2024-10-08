using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VeryRelaxedApi.Models;

namespace VeryRelaxedApi.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly MyDbContext _context;
        public PlayerRepository(MyDbContext context) 
        { 
            _context = context;
        }

        public async Task<List<Footballer>> GetAllPlayers()
        {
            var result = await _context.Footballers.ToListAsync();
            return result;
        }
        public async Task<Guid> GetPlayerGuidByPlayernameAsync(string playerName)
        {
            await Task.Delay(100);

            return Guid.NewGuid();
        }

        public async Task ChangePlayerNameAsync(string oldName, string newName)
        {
            var player = await _context.Footballers.FirstOrDefaultAsync(c => c.Name == oldName);
            if (player != null)
            {
                player.Name = newName;
                await _context.SaveChangesAsync();
            }
            return;
        }
        public async Task RegisterPlayer(string name, string age, string preferredFoot, string nationality)
        {
            var player = new Footballer { 
                Name = name,
                Age = Int32.Parse(age),
                PrefferedFoot = preferredFoot,
                Nationality = nationality,
                CreatedDate = DateTime.Now,
            };
            await _context.Footballers.AddAsync(player);

            await _context.SaveChangesAsync();
            return;
        }
    }
}

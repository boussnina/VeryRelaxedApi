using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VeryRelaxedApi.DTO;
using VeryRelaxedApi.Models;

namespace VeryRelaxedApi.Repository
{
    public class RefereeRepository : IRefereeRepository
    {
        private readonly MyDbContext _context;
        public RefereeRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<VeryRelaxedApi.Models.Referee>> GetAllReferees()
        {
            var result = await _context.Referees.ToListAsync();
            return result;
        }

        public async Task<Referee> AddReferee(RefereeDto referee)
        {
            var newRef = new Referee
            {
                Id = Guid.NewGuid(),
                Name = referee.Name,
                Age = referee.Age,
                Nationality = referee.Nationality,
                DateOfBirth = referee.DateOfBirth
            };

            await _context.Referees.AddAsync(newRef);
            await _context.SaveChangesAsync();

            return newRef;
        }

        public async Task<List<VeryRelaxedApi.Models.Referee>> GetRefereesWithBirthdayToday()
        {
            var today = DateTime.Today;

            var result = await _context.Referees
                .Where(referee => referee.DateOfBirth.Month == today.Month && referee.DateOfBirth.Day == today.Day)
                .ToListAsync();

            return result;
        }

    }
}

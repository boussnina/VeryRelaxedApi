using Microsoft.EntityFrameworkCore;
using VeryRelaxedApi.Models;

namespace VeryRelaxedApi.Repository
{
    public class CoachRepository : ICoachRepository
    {
        private readonly MyDbContext _context;

        public CoachRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Coach>> GetAllCoaches()
        {
            var result = await _context.Coaches.ToListAsync();
            return result;
        }

        public async Task AddCoach(string name, string nationality, string styleDescription, string age)
        {
            var newCoach = new Coach
            {
                Name = name,
                Nationality = nationality,
                StyleDescription = styleDescription,
                Age = Int32.Parse(age),
            };

            await _context.Coaches.AddAsync(newCoach);

            await _context.SaveChangesAsync();
        }
        public async Task RemoveCoach(Guid id)
        {
            var coach = await _context.Coaches.SingleOrDefaultAsync(c => c.Id == id);
            if (coach == null)
            {
                throw new InvalidOperationException("No couch found with given ID");
            }
            _context.Coaches.Remove(coach);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Coach>> SearchCoachToList(string searchword)
        {
            var coaches = await _context.Coaches
                .Where(c => 
                           c.Name.Contains(searchword)
                        || c.StyleDescription.Contains(searchword)
                        || c.Nationality.Contains(searchword)
                        || c.Age.ToString().Contains(searchword))
                .ToListAsync();
            return coaches ?? new List<Coach>();

            
        }
    }
}

using VeryRelaxedApi.Models;
using VeryRelaxedApi.Repository;
using VeryRelaxedApi.DTO;

namespace VeryRelaxedApi.BusinessLogic
{
    public class CoachBusinessLogic : ICoachBusinessLogic
    {
        private readonly ICoachRepository _coachRepository;
        public CoachBusinessLogic(ICoachRepository coachRepository) 
        { 
            _coachRepository = coachRepository;
        }

        public async Task<List<Coach>> GetAllCoaches()
        {
            var result = await _coachRepository.GetAllCoaches();
            return result;
        }

        public async Task AddCoach(CoachDto coach)
        {
            await _coachRepository.AddCoach(coach);

        }

        public async Task RemoveCoach(Guid id)
        {
            await _coachRepository.RemoveCoach(id);
        }

        public async Task<List<Coach>> SearchCoachToList(string searchword)
        {
            var result = await _coachRepository.SearchCoachToList(searchword);
            return result;
        }

    }
}

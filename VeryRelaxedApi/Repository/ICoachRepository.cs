using VeryRelaxedApi.Models;
using VeryRelaxedApi.DTO;

namespace VeryRelaxedApi.Repository

{
    public interface ICoachRepository
    {
        Task<List<Coach>> GetAllCoaches();

        Task AddCoach(CoachDto coach);

        Task RemoveCoach(Guid id);

        Task<List<Coach>> SearchCoachToList(string searchword);
    }
}

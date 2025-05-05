using VeryRelaxedApi.Models;
using VeryRelaxedApi.DTO;

namespace VeryRelaxedApi.BusinessLogic
{
    public interface ICoachBusinessLogic
    {
        Task<List<Coach>> GetAllCoaches();

        Task AddCoach(CoachDto coach);

        Task RemoveCoach(Guid id);

        Task<List<Coach>> SearchCoachToList(string searchword);

    }
}

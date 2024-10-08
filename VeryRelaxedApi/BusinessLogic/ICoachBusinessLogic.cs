using VeryRelaxedApi.Models;

namespace VeryRelaxedApi.BusinessLogic
{
    public interface ICoachBusinessLogic
    {
        Task<List<Coach>> GetAllCoaches();

        Task AddCoach(string name, string nationality, string styleDescription, string age);

        Task RemoveCoach(Guid id);

        Task<List<Coach>> SearchCoachToList(string searchword);

    }
}

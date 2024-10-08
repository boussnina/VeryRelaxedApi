using VeryRelaxedApi.Models;

namespace VeryRelaxedApi.Repository

{
    public interface ICoachRepository
    {
        Task<List<Coach>> GetAllCoaches();

        Task AddCoach(string name, string nationality, string styleDescription, string age);

        Task RemoveCoach(Guid id);

        Task<List<Coach>> SearchCoachToList(string searchword);
    }
}

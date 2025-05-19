using VeryRelaxedApi.DTO;
using VeryRelaxedApi.Models;

namespace VeryRelaxedApi.Repository
{
    public interface IRefereeRepository
    {
        Task<List<Referee>> GetAllReferees();

        Task<Referee> AddReferee(RefereeDto referee);

        Task<List<Referee>> GetRefereesWithBirthdayToday();
    }
}

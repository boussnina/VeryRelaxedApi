using VeryRelaxedApi.DTO;
using VeryRelaxedApi.Models;

namespace VeryRelaxedApi.BusinessLogic
{
    public interface IRefereeBusinessLogic
    {
        public Task<List<Referee>> getAllReferees();

        public Task<Referee> AddReferee(RefereeDto referee);

        public Task<List<Referee>> GetRefereesWithBirthdayToday();
    }
}

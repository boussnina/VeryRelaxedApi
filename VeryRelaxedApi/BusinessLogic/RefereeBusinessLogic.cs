using VeryRelaxedApi.Repository;
using VeryRelaxedApi.Models;
using VeryRelaxedApi.DTO;

namespace VeryRelaxedApi.BusinessLogic
{
    public class RefereeBusinessLogic : IRefereeBusinessLogic
    {
        private readonly IRefereeRepository _refereeRepository;

        public RefereeBusinessLogic(IRefereeRepository refereeRepository)
        {
            _refereeRepository = refereeRepository;
        }

        public async Task<List<Referee>> getAllReferees()
        {
            var result = await _refereeRepository.GetAllReferees();
            return result;

        }

        public async Task<Referee> AddReferee(RefereeDto referee)
        {
            var result = await _refereeRepository.AddReferee(referee);
            return result;
        }
        
        public async Task<List<Referee>> GetRefereesWithBirthdayToday()
        {
            var result = await _refereeRepository.GetRefereesWithBirthdayToday();
            return result;
        }


    }
}

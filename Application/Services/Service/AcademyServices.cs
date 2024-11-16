using AcademyManager.Application.DTO;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Domain.Repositories.QueryRepositories;

namespace AcademyManager.Application.Services.Service
{
    public class AcademyServices: IAcademyServices
    {
        private readonly IAcademyQueryRepository _academyQueryRepository;
        private readonly IAcademyCommandRepository _academyCommandRepository;

        public AcademyServices(IAcademyQueryRepository academyQueryRepository, IAcademyCommandRepository academyCommandRepository)
        {
            _academyQueryRepository = academyQueryRepository;
            _academyCommandRepository = academyCommandRepository;
        }


        public async Task<Guid> CreateNewAcademy(AcademyDto academyDto)
        {
            Academy academy = new()
            {
                Name = academyDto.Name,
            };

            await _academyCommandRepository.CreateAsync(academy);

            await _academyCommandRepository.SaveChangesAsync();
            return academy.Id;

        }

        public async Task<IEnumerable<Academy>> GetAllAcademiesAsync()
        {
            return await _academyQueryRepository.GetAllAsync();
        }

        public async Task<Academy> GetByAcademyIdAsync(Guid Id)
        {
            var academy = await _academyQueryRepository.GetByIdAsync(Id);
            return academy;
        }
    }
}

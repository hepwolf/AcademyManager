   using AcademyManager.Application.DTO;
   using AcademyManager.Domain.Entities;

namespace AcademyManager.Application.Services.Service
{
    public interface IAcademyServices
    {
        Task<Guid> CreateNewAcademy(AcademyDto academyDto);
        Task<IEnumerable<Academy>> GetAllAcademiesAsync();
        Task<Academy> GetByAcademyIdAsync(Guid Id);
    }
}

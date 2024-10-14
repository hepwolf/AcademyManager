using AcademyManager.Domain.Entities;
using AcademyManager.Model;

namespace AcademyManager.Domain.Repositories.CommandRepositories
{
    public interface IStudentCommandRepository : IGenericCommandRepository<Student>
    {
        Task RegisterStudentToCourseAsync(Guid studentId, Guid courseId, StudentCourseRegistrationModel registrationDto);
        Task<IEnumerable<StudentCourse>> GetStudentCoursesAsync(Guid studentId);
        Task<bool> UnregisterStudentFromCourseAsync(Guid studentId, Guid courseId);
        Task<bool> TransferStudentToNewCourseAsync(Guid studentId, Guid oldCourseId, Guid newCourseId);

    }
}

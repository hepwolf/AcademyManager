using AcademyManager.Application.DTO;
using AcademyManager.Domain.Entities;
using AcademyManager.Model;

namespace AcademyManager.Application.Services.Service
{
    public interface IStudentServices
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Guid> CreateNewStudentAsync(StudentDto studentDto);
        Task<Student> GetStudentByIdAsync(Guid studentId);
        Task<Guid> RegisterStudentToNewCourseAsync(Guid studentId, Guid courseId, StudentCourseRegistrationModel registrationDto);
        Task<IEnumerable<StudentCourseDto>> GetStudentCoursesBYIdAsync(Guid studentId);
        Task<bool> UnregisterStudentFromCourseAsync(Guid studentId, Guid courseId);
        Task<bool> TransferStudentToNewCourseAsync(Guid studentId, Guid oldCourseId, Guid newCourseId);
    }
}

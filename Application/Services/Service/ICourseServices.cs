using AcademyManager.Application.DTO;
using AcademyManager.Domain.Entities;

namespace AcademyManager.Application.Services.Service
{
    public interface ICourseServices
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(Guid courseId);
        Task<Guid> CreateNewCourseAsync(CourseDto courseDto);
        Task<bool> UpdateCourseMainStatusAsync(Guid courseId, bool isActive);
        Task<bool> CheckCourseTimeSlotAvailabilityAsync(DateTime startTime, DateTime endTime, Guid academyId);

    }
}

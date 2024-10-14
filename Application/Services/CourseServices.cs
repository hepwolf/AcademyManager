using AcademyManager.Application.DTO;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Domain.Repositories.QueryRepositories;
using System.Runtime.CompilerServices;

namespace AcademyManager.Application.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICourseCommandRepository _courseCommandRepository;
        private readonly ICourseQueryRepository _courseQueryRepository;

        public CourseServices(ICourseQueryRepository courseQueryRepository , ICourseCommandRepository courseCommandRepository   )
        {
                _courseCommandRepository = courseCommandRepository;
                _courseQueryRepository = courseQueryRepository; 
        }

        public async Task<Guid> CreateNewCourseAsync(CourseDto courseDto)
        {

            Course course = new()
            {
                AcademyId = courseDto.AcademyId,
                Name = courseDto.Name,
                StartTime = courseDto.StartTime,
                EndTime = courseDto.EndTime,
                IsActive = courseDto.IsActive
            };

            await _courseCommandRepository.CreateAsync(course);   
            await _courseCommandRepository.SaveChangesAsync();  
            return course.Id;


        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseQueryRepository.GetAllAsync();
        }

        public async Task<Course> GetCourseByIdAsync(Guid courseId)
        {
            return await _courseQueryRepository.GetByIdAsync(courseId); 
        }

        public async Task<bool> UpdateCourseMainStatusAsync(Guid courseId, bool isActive)
        {
            var course = await _courseQueryRepository.GetByIdAsync(courseId);
            if (course == null)

            {
                return false;
            }

            course.IsActive = isActive;
            await _courseCommandRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckCourseTimeSlotAvailabilityAsync(DateTime startTime, DateTime endTime, Guid academyId)
        {
            var courses = await _courseQueryRepository.GetAllAsync();
            return courses.Any(c => c.AcademyId == academyId &&
                       ((startTime >= c.StartTime && startTime < c.EndTime) ||
                        (endTime > c.StartTime && endTime <= c.EndTime) ||
                        (startTime <= c.StartTime && endTime >= c.EndTime)));
        }
    }
}

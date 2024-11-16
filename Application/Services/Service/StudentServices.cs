using AcademyManager.Application.DTO;
using AcademyManager.Application.Mapper;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Model;

namespace AcademyManager.Application.Services.Service
{
    public class StudentServices:IStudentServices
    {
        private readonly IStudentCommandRepository _studentCommandRepository;
        private readonly IStudentQueryRepository _studentQueryRepository;

        public StudentServices(IStudentQueryRepository studentQueryRepository, IStudentCommandRepository studentCommandRepository)
        {
            _studentCommandRepository = studentCommandRepository;
            _studentQueryRepository = studentQueryRepository;
        }
        public async Task<Guid> CreateNewStudentAsync(StudentDto studentDto)
        {
            Student newStudent = new()
            {
                Name = studentDto.Name,
            };
            await _studentCommandRepository.CreateAsync(newStudent);
            await _studentCommandRepository.SaveChangesAsync();
            return newStudent.Id;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentQueryRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(Guid studentId)
        {
            return await _studentQueryRepository.GetByIdAsync(studentId);
        }

        public async Task<IEnumerable<StudentCourseDto>> GetStudentCoursesBYIdAsync(Guid studentId)
        {
            var studentcourses = await _studentCommandRepository.GetStudentCoursesAsync(studentId);
            return studentcourses.ConvertToStudentCourseDtos();
        }

        public async Task<Guid> RegisterStudentToNewCourseAsync(Guid studentId, Guid courseId, StudentCourseRegistrationModel registrationDto)
        {
            StudentCourse studentCourse = new()
            {
                Name = registrationDto.Name,
                StudentId = studentId,
                CourseId = courseId
            };
            await _studentCommandRepository.RegisterStudentToCourseAsync(studentId, courseId, registrationDto);
            return studentCourse.Id;
        }

        public async Task<bool> TransferStudentToNewCourseAsync(Guid studentId, Guid oldCourseId, Guid newCourseId)
        {
            return await _studentCommandRepository.TransferStudentToNewCourseAsync(studentId, oldCourseId, newCourseId);
        }

        public async Task<bool> UnregisterStudentFromCourseAsync(Guid studentId, Guid courseId)
        {
            return await _studentCommandRepository.UnregisterStudentFromCourseAsync(studentId, courseId);
        }
    }
}

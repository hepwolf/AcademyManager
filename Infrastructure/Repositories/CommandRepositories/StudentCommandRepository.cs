using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Infrastructure.DbContexts;
using AcademyManager.Model;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infrastructure.Repositories.CommandRepositories
{
    public class StudentCommandRepository : IStudentCommandRepository
    {
        private readonly AcademyDbContext _context;

        public StudentCommandRepository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateAsync(Student entity)
        {
            await _context.Set<Student>().AddAsync(entity);
        }

        public void Delete(Student entity)
        {
            _context.Set<Student>().Remove(entity);
        }

        public void Update(Student entity)
        {
            _context.Set<Student>().Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task RegisterStudentToCourseAsync(Guid studentId, Guid courseId, StudentCourseRegistrationModel registrationDto)
        {
            var studentCourse = new StudentCourse
            {
                Name = registrationDto.Name,
                StudentId = studentId,
                CourseId = courseId
            };

            await _context.AddAsync(studentCourse);

            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<StudentCourse>> GetStudentCoursesAsync(Guid studentId)
        {
            return await _context.StudentCourses
           .Where(sc => sc.StudentId == studentId)
           .Include(sc => sc.Course)
           .ToListAsync();
        }

        public async Task<bool> UnregisterStudentFromCourseAsync(Guid studentId, Guid courseId)
        {
            var studentCourse = await _context.StudentCourses
            .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (studentCourse == null)
            {
                return false;
            }

            _context.StudentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> TransferStudentToNewCourseAsync(Guid studentId, Guid oldCourseId, Guid newCourseId)
        {
            var studentCourse = await _context.StudentCourses
          .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == oldCourseId);

            if (studentCourse == null)
            {
                return false;
            }


            _context.StudentCourses.Remove(studentCourse);


            StudentCourse newStudentCourse = new()
            {
                StudentId = studentId,
                CourseId = newCourseId,
            };

            await _context.StudentCourses.AddAsync(newStudentCourse);
            await _context.SaveChangesAsync();

            return true;
        }


    }

}

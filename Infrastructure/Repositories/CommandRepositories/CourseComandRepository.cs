using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Infrastructure.DbContexts;

namespace AcademyManager.Infrastructure.Repositories.CommandRepositories
{
    public class CourseComandRepository : ICourseCommandRepository

    {
        private readonly AcademyDbContext _context;

        public CourseComandRepository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateAsync(Course entity)
        {
            await _context.Set<Course>().AddAsync(entity);
        }

        public void Delete(Course entity)
        {
            _context.Set<Course>().Remove(entity);
        }

        public void Update(Course entity)
        {
            _context.Set<Course>().Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infrastructure.Repositories.QueryRepositories
{
    public class CourseQueryRipository : ICourseQueryRepository
    {
        private readonly AcademyDbContext _context;
        public CourseQueryRipository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Set<Course>().ToListAsync();
        }

        public async Task<Course> GetByIdAsync(Guid Id)
        {
            return await _context.Set<Course>().FindAsync(Id);
        }
    }
}

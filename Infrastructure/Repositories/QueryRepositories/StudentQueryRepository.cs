using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infrastructure.Repositories.QueryRepositories
{
    public class StudentQueryRepository : IStudentQueryRepository

    {
        private readonly AcademyDbContext _context;

        public StudentQueryRepository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Set<Student>().ToListAsync();
        }

        public async Task<Student> GetByIdAsync(Guid Id)
        {
            return await _context.Set<Student>().FindAsync(Id);
        }
    }
}

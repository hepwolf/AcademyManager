using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infrastructure.Repositories.QueryRepositories
{
    public class AcademyQueryRepository : IAcademyQueryRepository
    {
        private readonly AcademyDbContext _context;

        public AcademyQueryRepository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Academy>> GetAllAsync()
        {
            return await _context.Set<Academy>().ToListAsync();
        }

        public async Task<Academy> GetByIdAsync(Guid Id)
        {
            return await _context.Set<Academy>().FindAsync(Id);
        }
    }
}

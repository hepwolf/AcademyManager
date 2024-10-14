using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infrastructure.Repositories.QueryRepositories
{
    public class GenericQueryRepository<T> : IGenericQueryRepository<T> where T : class
    {
        private readonly AcademyDbContext _context;

        public GenericQueryRepository(AcademyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await _context.Set<T>().FirstAsync();
        }
    }
}

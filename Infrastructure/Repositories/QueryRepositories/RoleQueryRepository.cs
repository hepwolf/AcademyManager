using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infrastructure.Repositories.QueryRepositories
{
    public class RoleQueryRepository : IRoleQueryRepositry
    {
        private readonly AcademyDbContext _context;

        public RoleQueryRepository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Set<Role>().ToListAsync();    
        }

        public async Task<Role> GetByIdAsync(Guid Id)
        {
            return await _context.Set<Role>().FindAsync(Id);
        }

        public async Task<string> GetRoleNameById(Guid roleId)
        {
            return await _context.Set<Role>()
                .Where(r => r.Id == roleId)
                .Select(r => r.Name)  
                .FirstOrDefaultAsync();
        }


    }
}

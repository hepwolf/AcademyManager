using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Infrastructure.DbContexts;

namespace AcademyManager.Infrastructure.Repositories.CommandRepositories
{
    public class RoleCommandRepository : IRoleCommandRepository
    {
        private readonly AcademyDbContext _context;

        public RoleCommandRepository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateAsync(Role entity)
        {
            await _context.Set<Role>().AddAsync(entity);
        }

        public void Delete(Role entity)
        {
            _context.Set<Role>().Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}

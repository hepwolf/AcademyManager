using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Infrastructure.DbContexts;

namespace AcademyManager.Infrastructure.Repositories.CommandRepositories
{
    public class AcademyCommandRepository : IAcademyCommandRepository

    {
        private readonly AcademyDbContext _context;

        public AcademyCommandRepository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateAsync(Academy entity)
        {
            await _context.Set<Academy>().AddAsync(entity);
        }

        public void Delete(Academy entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Academy entity)
        {
            throw new NotImplementedException();
        }
    }

}

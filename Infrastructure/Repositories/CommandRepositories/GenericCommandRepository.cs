using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infrastructure.Repositories.CommandRepositories
{
    public class GenericCommandRepository<T> : IGenericCommandRepository<T> where T : class
    {

        private readonly AcademyDbContext _context;

        public GenericCommandRepository(AcademyDbContext context)
        {
            _context = context;
        }
        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }

}

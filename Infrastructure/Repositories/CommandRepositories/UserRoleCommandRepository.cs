using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Infrastructure.DbContexts;
using System;




namespace AcademyManager.Infrastructure.Repositories.CommandRepositories
{
    public class UserRoleCommandRepository : IUserRoleCommandRepository
    {
        private readonly AcademyDbContext _context;

        public UserRoleCommandRepository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateAsync(UserRole entity)
        {
            await _context.Set<UserRole>().AddAsync(entity);
        }

        public void Delete(UserRole entity)
        {
            _context.Set<UserRole>().Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;   
        }

        public void Update(UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}

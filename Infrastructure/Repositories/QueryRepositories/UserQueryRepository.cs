using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infrastructure.Repositories.QueryRepositories
{
    public class UserQueryRepository : IUserQueryRepository

    {
        private readonly AcademyDbContext _context;
        public UserQueryRepository(AcademyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserAccount>> GetAllAsync()
        {
            return await _context.Set<UserAccount>().ToListAsync();
        }

        public async Task<UserAccount> GetByIdAsync(Guid Id)
        {
           return await _context.Set<UserAccount>().FindAsync(Id);
        }

        public async Task<UserAccount> GetUserByEmailAsync(string email)
        {
            return await _context.UserAccunts.FirstOrDefaultAsync(u => u.Email == email);

        }
        public async Task<UserAccount> GetUserByUsernameAsync(string userName)
        {
            return await _context.UserAccunts.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<UserToken> GetUserTokenAsync(string token)
        {
            return await _context.UserTokens.FirstOrDefaultAsync(u => u.Token == token);    
        }
    }
}

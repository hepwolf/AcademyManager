using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Infrastructure.DbContexts;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AcademyManager.Infrastructure.Repositories.CommandRepositories
{
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly AcademyDbContext _context;
        public UserCommandRepository(AcademyDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(UserAccount user)
        {
           _context.UserAccunts.Add(user);
            
        }

        public async Task AddUserTokenAsync(UserToken userToken)
        {
            _context.UserTokens.Add(userToken); 
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

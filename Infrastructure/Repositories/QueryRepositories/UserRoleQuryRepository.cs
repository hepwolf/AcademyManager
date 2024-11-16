using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using static Paket.NuGetCache;

namespace AcademyManager.Infrastructure.Repositories.QueryRepositories
{

    public class UserRoleQuryRepository : IUserRoleQueryRepository
    {
        private readonly AcademyDbContext _context;

        public UserRoleQuryRepository(AcademyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.Set<UserRole>().ToListAsync();
        }

        public async Task<UserRole> GetByIdAsync(Guid Id)
        {
            return await _context.Set<UserRole>().FindAsync();
        }

        public async Task<UserRole> GetUserRoleAsync(Guid userId, Guid roleId)
        {  
           return await _context.UserRoles
           .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }

        public async Task<List<string>> GetUserRoleIdsAsync(Guid userId)
        {
            return await _context.UserRoles
             .Where(ur => ur.UserId == userId)
             .Select(ur => ur.Role.Id.ToString())  
                 .ToListAsync();
        }

        public async Task<List<string>> GetUserRolesAsync(Guid userId)
        {
            return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.Role.Name)  
            .ToListAsync();
        }
    }
}

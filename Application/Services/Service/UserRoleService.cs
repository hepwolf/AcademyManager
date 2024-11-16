using AcademyManager.Application.DTO;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Domain.Repositories.QueryRepositories;

namespace AcademyManager.Application.Services.Service
{
    public class UserRoleService:IUserRoleService
    {
        private readonly IUserRoleCommandRepository _userRoleCommandRepository;
        private readonly IUserRoleQueryRepository _userRoleQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IRoleQueryRepositry _roleQueryRepositry;
        public UserRoleService(IUserRoleCommandRepository userRoleCommandRepository, IUserRoleQueryRepository userRoleQueryRepository
          , IUserQueryRepository userQueryRepository, IRoleQueryRepositry roleQueryRepositry)
        {
            _userRoleCommandRepository = userRoleCommandRepository;
            _userRoleQueryRepository = userRoleQueryRepository;
            _userQueryRepository = userQueryRepository;
            _roleQueryRepositry = roleQueryRepositry;
        }
        public async Task<Guid?> AssignRoleToUserAsync(UserRoleDto userRoleDto)
        {
            var user = await _userQueryRepository.GetByIdAsync(userRoleDto.UserId);
            if (user == null) throw new KeyNotFoundException("User not found");

            var role = await _roleQueryRepositry.GetByIdAsync(userRoleDto.RoleId);
            if (role == null) throw new KeyNotFoundException("Role not found");

            var existingUserRole = await _userRoleQueryRepository.GetUserRoleAsync(userRoleDto.UserId, userRoleDto.RoleId);
            if (existingUserRole != null)
                return null;

            var newUserRole = new UserRole
            {
                UserId = userRoleDto.UserId,
                RoleId = userRoleDto.RoleId
            };

            await _userRoleCommandRepository.CreateAsync(newUserRole);
            await _userRoleCommandRepository.SaveChangesAsync();
            return newUserRole.Id;
        }

        public async Task<List<string>> GetUserRoleIdsAsync(Guid userId)
        {
            return await _userRoleQueryRepository.GetUserRoleIdsAsync(userId);
        }

        public async Task<List<string>> GetUserRolesAsync(Guid userId)
        {
            return await _userRoleQueryRepository.GetUserRolesAsync(userId);
        }

        public async Task<bool> RemoveRoleFromUserAsync(UserRoleDto userRoleDto)
        {
            var userRole = await _userRoleQueryRepository.GetUserRoleAsync(userRoleDto.UserId, userRoleDto.RoleId);
            if (userRole == null) return false;

            _userRoleCommandRepository.Delete(userRole);
            return await _userRoleCommandRepository.SaveChangesAsync();

        }

    }
}

using AcademyManager.Application.DTO;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Domain.Repositories.QueryRepositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AcademyManager.Application.Services.Service
{
    public class RoleServices:IRoleServices
    {
        private readonly IRoleCommandRepository _roleCommandRepository;
        private readonly IRoleQueryRepositry _roleQueryRepository;

        public RoleServices(IRoleCommandRepository roleCommandRepository, IRoleQueryRepositry roleQueryRepository)
        {
            _roleCommandRepository = roleCommandRepository;
            _roleQueryRepository = roleQueryRepository;
        }

       
        public async Task<Guid> AddRoleAsync(RoleDto roleDto)
        {
            var role = new Role
            {
                Name = roleDto.Name,
                Displayname = roleDto.Displayname
            };

            await _roleCommandRepository.CreateAsync(role);
            await _roleCommandRepository.SaveChangesAsync();

            return role.Id;
        }

        public async Task<bool> DeleteRoleAsync(Guid roleId)
        {
            var role = await _roleQueryRepository.GetByIdAsync(roleId);

            if (role == null)
            {
                throw new InvalidOperationException("Role not found.");
            }

            _roleCommandRepository.Delete(role);
            return await _roleCommandRepository.SaveChangesAsync();
        }

       
        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleQueryRepository.GetAllAsync();
            return roles.Select(role => new RoleDto
            {
                
                Name = role.Name,
                Displayname = role.Displayname
            }).ToList();
        }

        public async Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            return await _roleQueryRepository.GetByIdAsync(roleId);
            
        }

        public async Task<string> GetRoleNameByIdAsync(Guid roleId)
        {
            var roleName = await _roleQueryRepository.GetRoleNameById(roleId);

            if (string.IsNullOrEmpty(roleName))
            {
                throw new KeyNotFoundException("Role not found for the given roleId.");
            }

            return roleName;
        }
    }
}

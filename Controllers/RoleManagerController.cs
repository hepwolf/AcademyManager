using AcademyManager.Application.DTO;
using AcademyManager.Application.Services;
using AcademyManager.Application.Services.CustomAttribute;
using AcademyManager.Application.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyManager.Controllers
{
    [Authorize(Roles = "Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleManagerController: ControllerBase 
    {
        private readonly IRoleServices _roleServices;

        public RoleManagerController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [HttpGet("get-all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _roleServices.GetAllRolesAsync();
            return Ok(result);  
        }

        [HttpGet("get-role/{id}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            var role = await _roleServices.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound("Role not found.");
            }

            return Ok(role);
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var Id = await _roleServices.AddRoleAsync(roleDto);
            return Ok(Id);
        }

        [HttpDelete("delete-role/{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var isDeleted = await _roleServices.DeleteRoleAsync(id);
            if (!isDeleted)
            {
                return NotFound("Role not found.");
            }

            return Ok("Role deleted successfully.");
        }
    }
}

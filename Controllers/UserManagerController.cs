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
    public class UserManagerController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserManagerController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet("user-roles/{userId}")]
        public async Task<IActionResult> GetUserRoles(Guid userId)
        {
            try
            {
                
                var roles = await _userRoleService.GetUserRolesAsync(userId);

                if (roles == null || !roles.Any())
                {
                    return NotFound("No roles found for this user.");
                }

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] UserRoleDto userRoleDto)
        {
            try
            {
                var userRoleId = await _userRoleService.AssignRoleToUserAsync(userRoleDto);

                if (userRoleId == null)
                {
                    return BadRequest("Role is already assigned to the user.");
                }

                return Ok(new { message = "Role assigned to user successfully.", UserRoleId = userRoleId });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("remove-role")]
        public async Task<IActionResult> RemoveRoleFromUser(UserRoleDto userRoleDto)
        {
            try
            {
                var result = await _userRoleService.RemoveRoleFromUserAsync(userRoleDto);
                if (!result)
                {
                    return BadRequest("Role not found for this user.");
                }
                return Ok("Role removed from user successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}

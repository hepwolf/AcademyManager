using AcademyManager.Application.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace AcademyManager.Application.Services.CustomAttribute
{

    public class CustomAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string[] _requiredRoles;

        public CustomAuthorizeAttribute(params string[] requiredRoles)
        {
            _requiredRoles = requiredRoles;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user?.Identity?.IsAuthenticated == true)
            {
                var roleServices = context.HttpContext.RequestServices.GetService<IRoleServices>();
                var claimsIdentity = user.Identity as ClaimsIdentity;
                var roleIds = claimsIdentity?.FindAll("RoleId").Select(c => c.Value);

                if (roleIds != null && roleServices != null)
                {
                    foreach (var roleId in roleIds)
                    {
                        var roleName = await roleServices.GetRoleNameByIdAsync(Guid.Parse(roleId));
                        if (_requiredRoles.Contains(roleName))
                        {
                            return; 
                        }
                    }
                }
            }

            
            context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.HttpContext.Response.WriteAsync("Access Denied");
        }
    }


}

using AcademyManager.Application.Services.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AcademyManager.Middelware
{
    public class RoleClaimsMiddleware : IMiddleware
    {
        private readonly IRoleServices _roleServices;

        public RoleClaimsMiddleware(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var user = context.User;
            if (user?.Identity?.IsAuthenticated == true)
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                var roleIds = claimsIdentity?.FindAll("RoleId").Select(c => c.Value).ToList();

                if (roleIds != null)
                {
                    var newClaims = new List<Claim>();
                    foreach (var roleId in roleIds)
                    {
                        var roleName = await _roleServices.GetRoleNameByIdAsync(Guid.Parse(roleId));
                        if (!string.IsNullOrEmpty(roleName))
                        {
                            newClaims.Add(new Claim(ClaimTypes.Role, roleName));
                        }
                    }


                    claimsIdentity.AddClaims(newClaims);


                }
            }

            await next(context);
        }


    }

}




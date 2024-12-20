﻿using AcademyManager.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcademyManager.Application.Services.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRoleService _userRoleService;


        public JwtTokenGenerator(IConfiguration configuration, IUserRoleService userRoleService)
        {
            _configuration = configuration;
            _userRoleService = userRoleService;
        }
        public async Task<string> GenerateTokenAsync(UserAccount user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim("UserId", user.Id.ToString())


    };

            var roleIds = await _userRoleService.GetUserRoleIdsAsync(user.Id);

            foreach (var roleId in roleIds)
            {
                claims.Add(new Claim("RoleId", roleId));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

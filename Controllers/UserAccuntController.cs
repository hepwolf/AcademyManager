using AcademyManager.Application.DTO;
using AcademyManager.Application.Services.Service;
using AcademyManager.Application.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core.Tokenizer;

namespace AcademyManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccuntController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserAccuntController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            
            RegisterValidator lValidator = new RegisterValidator();
            await lValidator.ValidateAndThrowAsync(registerDto); 


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = await _userServices.RegisterUserAsync(registerDto);

            if (newUser == null)
            {
                return BadRequest("Registration failed, user already exists or invalid data");
            }

             
            return Ok(newUser.Id);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginDto)
        {
            LoginValidator lValidator = new LoginValidator();
            await lValidator.ValidateAndThrowAsync(loginDto);

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest("Invalid login request");
            //}

            var token = await _userServices.LoginUserAsync(loginDto);

            //if (token == null)
            //{
            //    return Unauthorized("Invalid credentials");
            //}

            return Ok(new { Token = token });
        }
    }

   
}
    
    




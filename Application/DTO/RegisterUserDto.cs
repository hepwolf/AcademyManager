﻿using System.ComponentModel.DataAnnotations;

namespace AcademyManager.Application.DTO
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

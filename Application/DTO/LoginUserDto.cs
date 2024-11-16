using System.ComponentModel.DataAnnotations;

namespace AcademyManager.Application.DTO
{
    public class LoginUserDto
    {
        public string UserName { get; set;}
        public string Password { get; set; }
    }
}

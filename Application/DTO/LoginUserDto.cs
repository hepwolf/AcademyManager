using System.ComponentModel.DataAnnotations;

namespace AcademyManager.Application.DTO
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set;}

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}

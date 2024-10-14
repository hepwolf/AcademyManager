using System.ComponentModel.DataAnnotations;

namespace AcademyManager.Application.DTO
{
    public class RegisterUserDto
    {
        

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "Max 50 charcters allowd")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(50, ErrorMessage = "max 50 charcters allowd")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage = "max 100 charcter allowd")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is requrid")]
        [MaxLength(20, ErrorMessage = "max 20 charcter allowd")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "passeord is requridd")]
        [MaxLength(20, ErrorMessage = "max 20 charcter allowd")]
        public string Password { get; set; }
    }
}

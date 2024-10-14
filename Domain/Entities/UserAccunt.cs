using AcademyManager.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcademyManager.Domain.Entities
{
    [Index(nameof(Email),IsUnique =true)]
    [Index(nameof(UserName),IsUnique =true)]    
    public class UserAccount 
    {

        //
        // Constructor
        //
        public UserAccount()
        {
            // Initialize the collection of tokens
            UserTokens = new List<UserToken>();
        }

        //
        // Properties
        //
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        // Navigation property for related tokens
        public virtual ICollection<UserToken> UserTokens { get; set; } // One-to-many relationship

        // Navigation property for ralated role
        public virtual ICollection<UserRole> UserRoles { get; set; } // Many-to-many relationship
    }
}

using AcademyManager.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyManager.Domain.Entities
{
    public class UserToken
    {
        //
        // Properties
        // 

        [Key]
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }


        //
        // Navigation properties
        // 

        [ForeignKey("UserAccunt")]
        public Guid UserId { get; set; }
        public UserAccount User  { get; set; }

    }
}

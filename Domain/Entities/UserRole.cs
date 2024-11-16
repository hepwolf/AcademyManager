using AcademyManager.Domain.Shared;

namespace AcademyManager.Domain.Entities
{
    public class UserRole : EntityBase
    {
        public Guid UserId { get; set; }
        public UserAccount UserAccunt { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}

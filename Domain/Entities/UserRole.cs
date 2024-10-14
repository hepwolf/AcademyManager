namespace AcademyManager.Domain.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public UserAccount UserAccunt { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}

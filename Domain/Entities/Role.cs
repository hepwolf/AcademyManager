namespace AcademyManager.Domain.Entities
{
    public class Role
    {

        //
        // Constructor
        //
        public Role()
        {
            
        }
        //
        // Properties
        //
        public int Id { get; set; }
        public string Name { get; set; }
        public string Displayname { get; set; }

        //
        // Navigation properties
        //
        public virtual ICollection<UserRole> UserRoles { get; set; } // Many-to-many relationship
    }
}

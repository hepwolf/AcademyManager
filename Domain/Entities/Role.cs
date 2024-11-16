using AcademyManager.Domain.Shared;

namespace AcademyManager.Domain.Entities
{
    public class Role:EntityBase
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
        public string Name { get; set; }
        public string Displayname { get; set; }

        //
        // Navigation properties
        //
        public virtual ICollection<UserRole> UserRoles { get; set; } // Many-to-many relationship
    }
}

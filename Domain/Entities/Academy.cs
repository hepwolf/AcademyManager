using AcademyManager.Domain.Shared;

namespace AcademyManager.Domain.Entities
{
    public class Academy : EntityBase
    {
        //
        // Constructor
        //
        public Academy()
        {
            
        }

        //
        // Properties
        //
        public string Name { get; set; }

        //
        // Navigation properties
        //
        public virtual ICollection<Course> Courses { get; set; }
    }
}

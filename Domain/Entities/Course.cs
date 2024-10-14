using AcademyManager.Domain.Shared;

namespace AcademyManager.Domain.Entities
{
    public class Course : EntityBase
    {
        //
        // Constructor
        //
        public Course()
        {
            
        }

        //
        // Properties
        //
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }

        //
        // Navigation properties
        //
        public virtual Guid AcademyId { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

    }
}

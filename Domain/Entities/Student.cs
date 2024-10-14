using AcademyManager.Domain.Shared;

namespace AcademyManager.Domain.Entities
{
    public class Student:EntityBase
    {
        //
        // Constructor
        //
        public Student()
        {

        }    
        //
        // Properties
        //
        public string Name { get; set; }
        //
        // Navigation properties
        //
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}


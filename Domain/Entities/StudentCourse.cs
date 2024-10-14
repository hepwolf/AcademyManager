using AcademyManager.Domain.Shared;

namespace AcademyManager.Domain.Entities
{
    public class StudentCourse: EntityBase
    {
        public string Name { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}

namespace AcademyManager.Model
{
    public class StudentCourseRegistrationModel
    {
        public string Name { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}

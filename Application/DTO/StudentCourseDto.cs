namespace AcademyManager.Application.DTO
{
    public class StudentCourseDto
    {
        public string Name { get; set; }    
        public Guid Id { get; set; } 
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}

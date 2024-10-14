namespace AcademyManager.Application.DTO
{
    public class UpdateCourseStatusDto
    {
        public Guid CourseId { get; set; }
        public bool IsActive { get; set; }
    }
}

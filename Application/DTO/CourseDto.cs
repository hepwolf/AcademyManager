namespace AcademyManager.Application.DTO
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid AcademyId { get; set; }
    }
}

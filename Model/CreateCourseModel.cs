namespace AcademyManager.Model
{
    public class CreateCourseModel
    {
        
        public Guid AcademyId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }        
    }
}

namespace AcademyManager.Model
{
    public class TransferStudentModel
    {
        public string Name { get; set; }
        public Guid StudentId { get; set; }
        public Guid OldCourseId { get; set; }
        public Guid NewCourseId { get; set; }
    }
}

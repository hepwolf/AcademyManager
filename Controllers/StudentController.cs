using AcademyManager.Application.DTO;
using AcademyManager.Application.Mapper;
using AcademyManager.Application.Services;
using AcademyManager.Application.Services.Service;
using AcademyManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace AcademyManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }


        [HttpGet("get-all-student")]
        public async Task<IActionResult> GetAllStudent()
        {
            var student = await _studentServices.GetAllStudentsAsync();
            return Ok(student);
        }

        [HttpGet("{studentId}")]

        public async Task<ActionResult<StudentDto>> GetStudent(Guid studentId)
        {
            var student = await _studentServices.GetStudentByIdAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }
            var studentDto = student;
            return Ok(studentDto);


        }

        [HttpGet("{studentId}/courses")]
        public async Task<IActionResult> GetStudentCourses(Guid studentId)
        {
            var studentCourses = await _studentServices.GetStudentCoursesBYIdAsync(studentId);

            if (studentCourses == null || !studentCourses.Any())
            {
                return NotFound("No courses found for this student.");
            }

            return Ok(studentCourses);

        }

        [HttpPost]
        public async Task<IActionResult>CreatSudent([FromBody] CreateStudentModel createStudentModel)
        {

            StudentDto newStudent = new()
            {
                Name = createStudentModel.Name,
            };
            var id = await _studentServices.CreateNewStudentAsync(newStudent);
            return Ok(id);
        }

        [HttpPost("studentId/register")]
        public async Task<IActionResult> RegisterStudentToCourse([FromBody] StudentCourseRegistrationModel studentCourseRegistrationModel )
        {

            var registrationId = await _studentServices.RegisterStudentToNewCourseAsync(studentCourseRegistrationModel.StudentId, studentCourseRegistrationModel.CourseId, studentCourseRegistrationModel);



            return Ok(registrationId);

        }

        [HttpPut("transfer")]
        public async Task<IActionResult> TransferStudentToNewCourse([FromBody] TransferStudentModel model)
        {
            var success = await _studentServices.TransferStudentToNewCourseAsync(model.StudentId, model.OldCourseId, model.NewCourseId);

            if (!success)
            {
                return NotFound(new { Message = "Student is not enrolled in the old course or courses not found." });
            }

            return Ok(new { Message = "Student successfully transferred to the new course." });
        }

        [HttpDelete("{studentId}/courses/{courseId}")]
        public async Task<IActionResult> UnregisterStudentFromCourse(Guid studentId, Guid courseId)
        {
            var success = await _studentServices.UnregisterStudentFromCourseAsync(studentId, courseId);

            if (!success)
            {
                return NotFound(new { Message = "Registration not found or student is not enrolled in the course." });
            }

            return NoContent(); 
        }

    }

}

using AcademyManager.Application.DTO;
using AcademyManager.Application.Services;
using AcademyManager.Domain.Entities;
using AcademyManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AcademyManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices _courseServices;   

        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        [HttpGet("get-all-course")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseServices .GetAllCoursesAsync();


            if (courses == null || !courses.Any())
            {
                return NotFound();
            }

            var courseDtos = courses;

            return Ok(courseDtos);
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<CourseDto>> GetCourse(Guid courseId)
        {
            var course = await _courseServices.GetCourseByIdAsync(courseId);

            if (course == null)
            {
                return NotFound();
            }

            var courseDto = course;

            return Ok(courseDto);
        }


        [HttpPost("creat-course")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseModel model)
        {
            if (await _courseServices.CheckCourseTimeSlotAvailabilityAsync(model.StartTime, model.EndTime, model.AcademyId))
            {
                return Conflict("A course is already scheduled during this time slot.");
            }

            try
            {
                CourseDto courseDto = new()
                {
                    AcademyId = model.AcademyId,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    IsActive = model.IsActive,
                    Name = model.Name,
                };
                var courseId = await _courseServices.CreateNewCourseAsync(courseDto);
                return Ok(courseId);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (ex.Message));
            }
                
        }
        [HttpPut("status")]
        public async Task<IActionResult> UpdateCourseStatus([FromBody] UpdateCourseModel updateCourseModel )
        {
            var isActive = await _courseServices.UpdateCourseMainStatusAsync(updateCourseModel.CourseId, updateCourseModel.IsActive);

            if (!isActive)
            {
                return NotFound();
            }

            return NoContent();
        }


    }


}

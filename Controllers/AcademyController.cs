using AcademyManager.Application.DTO;
using AcademyManager.Application.Mapper;
using AcademyManager.Application.Services;
using AcademyManager.Application.Services.Service;
using AcademyManager.Domain.Entities;
using AcademyManager.Domain.Repositories;
using AcademyManager.Infrastructure.Repositories;
using AcademyManager.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AcademyManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcademyController : ControllerBase
    {
        private readonly IAcademyServices _academySevices;

        public AcademyController(IAcademyServices academySevices)
        {
            _academySevices = academySevices;
        }

        [HttpGet("get-all-academies")]
        public async Task<IActionResult> GetAllAcademies()
        {
            var result = await _academySevices.GetAllAcademiesAsync();
            return Ok(result);
        }

        [HttpPost("create-academy")]
        public async Task<IActionResult> CreateAcademy([FromBody] CreateAcademyModel model) 
        {
            AcademyDto academyDto = new()
            {
                Name = model.Name,
            };
            var id = await _academySevices.CreateNewAcademy(academyDto);
            return Ok(id);
        }

       
    }
}

using ProjectSchool.Dtos;
using ProjectSchool.Model;
using ProjectSchool.Services.StudentService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace dotnet_rpg.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class StudentInfoController : ControllerBase
    {

        private readonly IStudentService _StudentService;

        public StudentInfoController(IStudentService studentService)
        {
            _StudentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetStudentsDto>>>> Get()
        {
            return Ok(await _StudentService.GetAllStudents());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStudentsDto>>>> AddStudent(AddStudentDto newStudent)
        {
            return Ok(await _StudentService.AddStudent(newStudent));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentsDto>>> GetStudentById(int id)
        {
            return Ok(await _StudentService.GetStudentById(id));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentsDto>>> DeleteStudentById(int id)
        {
            var response = await _StudentService.DeleteStudentById(id);
            if (response.Data is null)
            {
                return (NotFound(response));
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetStudentsDto>>>> UpdateStudentById(UpdateStudentDto updatedStudent)
        {
            var response = await _StudentService.UpdateStudentById(updatedStudent);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
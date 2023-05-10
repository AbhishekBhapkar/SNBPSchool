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

    }
}
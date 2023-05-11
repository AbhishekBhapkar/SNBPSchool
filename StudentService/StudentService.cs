using ProjectSchool.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectSchool.Data;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool.Dtos;

namespace ProjectSchool.Services.StudentService
{
    public class StudentService : IStudentService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StudentService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetStudentsDto>>> GetAllStudents()
        {
            var ServiceResponse = new ServiceResponse<List<GetStudentsDto>>();
            var dbStudents = await _context.Students.ToListAsync();
            ServiceResponse.Data = dbStudents.Select(c => _mapper.Map<GetStudentsDto>(c)).ToList();
            return ServiceResponse;
        }
        public async Task<ServiceResponse<List<GetStudentsDto>>> AddStudent(AddStudentDto newStudentAdd)
        {
            var ServiceResponse = new ServiceResponse<List<GetStudentsDto>>();
            var student = _mapper.Map<Students>(newStudentAdd);
            //student.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return ServiceResponse;
        }
        public async Task<ServiceResponse<GetStudentsDto>> GetStudentById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetStudentsDto>();
            var dbStudents = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            ServiceResponse.Data = _mapper.Map<GetStudentsDto>(dbStudents);
            return ServiceResponse;
        }
        public async Task<ServiceResponse<List<GetStudentsDto>>> DeleteStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentsDto>>();

            var student = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            if (student is null)
                throw new Exception($"Student with Id '{id}' not found");

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Students.Select(c => _mapper.Map<GetStudentsDto>(c)).ToListAsync();

            return serviceResponse;
        }
        public async Task<ServiceResponse<GetStudentsDto>> UpdateStudentById(UpdateStudentDto UpdatedStudent)
        {
            var ServiceResponse = new ServiceResponse<GetStudentsDto>();

            var student = await _context.Students.FirstOrDefaultAsync(c => c.Id == UpdatedStudent.Id);
            if (student is null)
                throw new Exception($"Student with Id '{UpdatedStudent.Id}' not found");

            student.StudentFirstName = UpdatedStudent.StudentFirstName;
            student.StudentMiddleName = UpdatedStudent.StudentMiddleName;
            student.StudentLastName = UpdatedStudent.StudentLastName;
            student.classroom = UpdatedStudent.classroom;
            student.section = UpdatedStudent.section;

            await _context.SaveChangesAsync();
            ServiceResponse.Data = _mapper.Map<GetStudentsDto>(student);
            return ServiceResponse;
        }

    }
}
using AutoMapper;
using ProjectSchool.Dtos;
using ProjectSchool.Model;

namespace GodProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Students,GetStudentsDto>();
            CreateMap<AddStudentDto,Students>();
  
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Dtos.StudentDtos;
using UniverstyTMS.Dtos.TeacherDtos;
using UniverstyTMS.Dtos.UserDtos;
using UniverstyTMS.Helper;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;

        public UserController(ISpecialtyRepository specialtyRepository,IGroupRepository groupRepository,ITeacherRepository teacherRepository,IStudentRepository studentRepository, ITypeRepository typeRepository,IFacultyRepository facultyRepository , IMapper mapper)
        {
            _specialtyRepository = specialtyRepository;
            _groupRepository = groupRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
            _typeRepository = typeRepository;
            _facultyRepository = facultyRepository;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto postDto)
        {
            Student student = _studentRepository.Get(x => x.Id == postDto.Id);
            if(student!=null&&student.Password == postDto.Password) 
            {
                var data = _mapper.Map<StudentLoginGetDto>(student);
                data.Type = _typeRepository.Get(x=>x.Id == student.TypeId).Name;
                data.Img = "https://localhost:7046/uploads/students/" + data.Img;
                int specalityId = _groupRepository.Get(x=>x.Id==student.GroupId).SpecialtyId;
                var specality = _specialtyRepository.Get(x => x.Id == specalityId);
                data.Specialty = specality.Name;
                data.Faculty = _facultyRepository.Get(x => x.Id == specality.FacultyId).Name;
                return StatusCode(201, new { token="Token",user = data });
            }
            Teacher teacher = _teacherRepository.Get(x => x.Id == postDto.Id);
            if(teacher!=null&&teacher.Password == postDto.Password)
            {
                var data = _mapper.Map<TeacherLoginGetDto>(teacher);
                data.Type = _typeRepository.Get(x => x.Id == teacher.TypeId).Name;
                data.Faculty = _facultyRepository.Get(x => x.Id == teacher.FacultyId).Name;
                data.Img = "https://localhost:7046/uploads/teachers/" + data.Img;
                return StatusCode(201, new { token = "Token", user = data });
            }

            return StatusCode(404, new {msg="Sifre ve ya password sehvdir"});
        }
    }
}

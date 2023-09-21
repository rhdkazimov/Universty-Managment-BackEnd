using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.GroupDtos;
using UniverstyTMS.Dtos.SettingDtos;
using UniverstyTMS.Dtos.SpecialtyDtos;
using UniverstyTMS.Dtos.TeacherDtos;
using UniverstyTMS.Helper;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository,IGroupRepository groupRepository,IStudentRepository studentRepository,IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create([FromForm] TeacherPostDto postDto)
        {
            Teacher teacher = _mapper.Map<Teacher>(postDto);

            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
            teacher.Img = FileManager.Save(postDto.ImageFile, rootPath, "uploads/teachers");

            _teacherRepository.Add(teacher);
            _teacherRepository.Commit();

            return StatusCode(201, new { teacher.Id });
        }

        [HttpGet("all")]
        public ActionResult<List<TeacherGetDto>> GetAll()
        {
            var data = _mapper.Map<List<TeacherGetDto>>(_teacherRepository.GetAll(x => true,"Faculty","Type"));
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<TeacherGetByIdDto> Get(int id)
        {
            Teacher teacher = _teacherRepository.Get(x => x.Id == id, "Faculty","Type");

            if (teacher == null) return NotFound();

            var data = _mapper.Map<TeacherGetByIdDto>(teacher);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Teacher teacher = _teacherRepository.Get(x => x.Id == id);

            if (teacher == null)
                return NotFound();

            _teacherRepository.Remove(teacher);
            _teacherRepository.Commit();

            return NoContent();
        }

        [HttpGet("group/students/{id}")]
        public ActionResult<GroupStudentsGetDto> GetGroups(int id)
        {
            Group group = _groupRepository.Get(x => x.Id == id);
            if (group == null) return NotFound();

            var data = _mapper.Map<GroupStudentsGetDto>(group);

            //List<Student> students = _studentRepository.GetAll(x => x.GroupId == group.Id);
            var studentsData = _mapper.Map<List<StudentInGroupGetDto>>(_studentRepository.GetAll(x => x.GroupId == group.Id));

            foreach (var student in studentsData)
            {
            data.Students.Add(student);
            }

            return Ok(data);
        } 

    }
}

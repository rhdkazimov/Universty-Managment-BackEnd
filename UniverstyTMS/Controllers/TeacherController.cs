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
        private readonly IGradesRepository _gradesRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupLessonRepository _groupLessonRepository;
        private readonly IMapper _mapper;

        public TeacherController(IGradesRepository gradesRepository,ITeacherRepository teacherRepository,IGroupRepository groupRepository,IStudentRepository studentRepository, IGroupLessonRepository groupLessonRepository,IMapper mapper)
        {
            _gradesRepository = gradesRepository;
            _teacherRepository = teacherRepository;
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
            _groupLessonRepository = groupLessonRepository;
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
        public ActionResult<GroupStudentsGetDto> GetGroupStudents(int id)
        {
            Group group = _groupRepository.Get(x => x.Id == id);
            if (group == null) return NotFound();

            var data = _mapper.Map<GroupStudentsGetDto>(group);

            //List<Student> students = _studentRepository.GetAll(x => x.GroupId == group.Id);
            var studentsData = _mapper.Map<List<StudentInGroupGetDto>>(_studentRepository.GetAll(x => x.GroupId == group.Id));

            int studentIndex = 0;
            foreach (var student in studentsData)
            {
                var studentGrade = _gradesRepository.Get(x=>x.Id == student.Id);
                data.Students.Add(student);
                data.Students[studentIndex].SDF1 = studentGrade.SDF1;
                data.Students[studentIndex].SDF2= studentGrade.SDF2;
                data.Students[studentIndex].SDF3 = studentGrade.SDF3;
                data.Students[studentIndex].TSI = studentGrade.TSI;
                data.Students[studentIndex].SSI = studentGrade.SSI;
                data.Students[studentIndex].ORT = studentGrade.ORT;
                studentIndex++;
            }

            return Ok(data);
        }

        [HttpGet("groups/{id}")]
        public ActionResult<List<TeacherGroupDto>> GetGroups(int id)
        {
            var groups = _groupLessonRepository.GetAll(x => x.TeacherId == id);

            var data = _mapper.Map<List<TeacherGroupDto>>(_groupLessonRepository.GetAll(x => x.TeacherId == id,"Lesson","Group"));

            foreach (var item in data)
            {
                item.Group.StudentsCount = _studentRepository.GetAllQueryable(x => true).Count(x => x.GroupId == item.Group.Id);
            }

            return Ok(data);
        }

    }
}

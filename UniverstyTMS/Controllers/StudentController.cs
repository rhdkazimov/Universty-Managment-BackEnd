using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.StudentDtos;
using UniverstyTMS.Dtos.TeacherDtos;
using UniverstyTMS.Helper;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IAttanceRepository _attanceRepository;
        private readonly IGroupLessonRepository _groupLessonRepository;
        private readonly IGradesRepository _gradesRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, ILessonRepository lessonRepository, IAttanceRepository attanceRepository, IGroupLessonRepository groupLessonRepository, IGradesRepository gradesRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _lessonRepository = lessonRepository;
            _attanceRepository = attanceRepository;
            _groupLessonRepository = groupLessonRepository;
            _gradesRepository = gradesRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create([FromForm] StudentPostDto postDto)
        {
            Student student = _mapper.Map<Student>(postDto);

            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
            student.Img = FileManager.Save(postDto.ImgFile, rootPath, "uploads/students");

            _studentRepository.Add(student);
            _studentRepository.Commit();

            var groupLesson = _groupLessonRepository.GetAll(x => x.GroupId == student.GroupId);

            foreach (var item in groupLesson)
            {

                Grades grade = new Grades
                {
                    ORT = 0,
                    SDF1 = 0,
                    SDF2 = 0,
                    SDF3 = 0,
                    TSI = 0,
                    SSI = 0,
                    StudentId = student.Id,
                    LessonId = item.LessonId,
                };

                _gradesRepository.Add(grade);
                _gradesRepository.Commit();

                Lesson lesson = _lessonRepository.Get(x => x.Id == item.LessonId);

                for (int i = 0; i < lesson.Hours - 1; i++)
                {
                    Attance attance = new Attance
                    {
                        StudentId = student.Id,
                        LessonId = lesson.Id,
                        DVM = "-"
                    };
                    _attanceRepository.Add(attance);
                    _attanceRepository.Commit();
                }
            }


            return StatusCode(201, new { student.Id });
        }

        [HttpGet("all")]
        public ActionResult<List<StudentGetDto>> GetAll()
        {
            var data = _mapper.Map<List<StudentGetDto>>(_studentRepository.GetAll(x => true, "Group", "Type"));
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<StudentGetDto> Get(int id)
        {
            Student student = _studentRepository.Get(x => x.Id == id, "Group", "Type");

            if (student == null) return NotFound();

            var data = _mapper.Map<StudentGetDto>(student);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student student = _studentRepository.Get(x => x.Id == id);

            if (student == null)
                return NotFound();

            _studentRepository.Remove(student);
            _studentRepository.Commit();

            return NoContent();
        }
    }
}

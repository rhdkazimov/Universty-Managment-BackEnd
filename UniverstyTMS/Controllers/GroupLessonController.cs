using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.GroupLessonDtos;
using UniverstyTMS.Dtos.LessonDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GroupLessonController : ControllerBase
    {
        private readonly IGroupLessonRepository _groupLessonRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IGradesRepository _gradesRepository;
        private readonly IAttanceRepository _attanceRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupLessonController(IGroupLessonRepository groupLessonRepository,ILessonRepository lessonRepository,IGradesRepository gradesRepository,IAttanceRepository attanceRepository,IStudentRepository studentRepository, IGroupRepository groupRepository, IMapper mapper)
        {
            _gradesRepository = gradesRepository;
            _groupLessonRepository = groupLessonRepository;
            _lessonRepository = lessonRepository;
            _attanceRepository = attanceRepository;
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public ActionResult<List<GroupLessonsGetDto>> GetAll()
        {
            string[] includes = { "Lesson", "Group" };

            return Ok(_mapper.Map<List<GroupLessonsGetDto>>(_groupLessonRepository.GetAll(X => true, "Lesson", "Group", "Teacher")));
        }

        [HttpPost("")]
        public IActionResult Create(GroupLessonsPostDto postDto)
        {
            GroupLessons groupLesson = _mapper.Map<GroupLessons>(postDto);

            var group = _groupRepository.Get(x => x.Id == postDto.GroupId).GroupLessons.FirstOrDefault(x => x.LessonId == postDto.LessonId);


            if (group == null)
            {
              var students = _studentRepository.GetAll(x=>x.GroupId==postDto.GroupId);

                foreach (var student in students)
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
                        LessonId = postDto.LessonId,
                    };

                    _gradesRepository.Add(grade);
                    _gradesRepository.Commit();

                    Lesson lesson = _lessonRepository.Get(x => x.Id == postDto.LessonId);

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
            }

            _groupLessonRepository.Add(groupLesson);
            _groupLessonRepository.Commit();


            return StatusCode(201, new { groupLesson.Id });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            GroupLessons gl = _groupLessonRepository.Get(x => x.Id == id);

            if (gl == null)
                return NotFound();

            _groupLessonRepository.Remove(gl);
            _groupLessonRepository.Commit();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, GroupLessonsPostDto putDto)
        {
            GroupLessons gl = _groupLessonRepository.Get(x => x.Id == id);

            if (gl == null)
                return NotFound();

            gl.LessonId = putDto.LessonId;
            gl.GroupId = putDto.GroupId;
            _groupLessonRepository.Commit();

            return NoContent();
        }
    }
}

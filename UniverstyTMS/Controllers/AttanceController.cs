using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.AnnounceDtos;
using UniverstyTMS.Dtos.AttanceDtos;
using UniverstyTMS.Dtos.FacultyDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttanceController : ControllerBase
    {
        private readonly IAttanceRepository _attanceRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IGroupLessonRepository _groupLessonRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public AttanceController(IAttanceRepository attanceRepository,ITeacherRepository teacherRepository,IGroupLessonRepository groupLessonRepository ,ILessonRepository lessonRepsository, IStudentRepository studentRepository, IMapper mapper)
        {
            _attanceRepository = attanceRepository;
            _teacherRepository = teacherRepository;
            _groupLessonRepository = groupLessonRepository;
            _lessonRepository = lessonRepsository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create(AttancePostDto postDto)
        {
            //Attance attance = _mapper.Map<Attance>(postDto);

            Lesson lesson = _lessonRepository.Get(x => x.Id == postDto.LessonId);

            for (int i = 0; i < lesson.Hours - 1; i++)
            {
                Attance attance = new Attance
                {
                    StudentId = postDto.StudentId,
                    LessonId = postDto.LessonId,
                    DVM = "-"
                };
                _attanceRepository.Add(attance);
                _attanceRepository.Commit();
            }

            return StatusCode(201);
        }

        [HttpGet("all")]
        public ActionResult<List<AttanceGetDto>> GetAll()
        {
            var students = _studentRepository.GetAll(x => true);
            var attances = _attanceRepository.GetAll(x => true);

            List<AttanceGetDto> data = new List<AttanceGetDto>();

            foreach (var student in students)
            {
                AttanceGetDto attance = new AttanceGetDto
                {
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    SurName = student.SurName,
                };
                foreach (var att in attances)
                {
                    if (att.StudentId == student.Id)
                    {
                        DVMInAttanceGetDto dVMInAttanceGetDto = new DVMInAttanceGetDto
                        {
                            DVM = att.DVM
                        };
                        attance.attance.Add(dVMInAttanceGetDto);
                    }
                }
                data.Add(attance);
            }
            return Ok(data);
        }

        [HttpGet("group/{id}/{lessonId}")]
        public ActionResult<List<AttanceGetDto>> GroupAttance(int id, int lessonId)
        {
            var students = _studentRepository.GetAll(x => x.GroupId == id);
            var attances = _attanceRepository.GetAll(x => x.LessonId == lessonId);

            List<AttanceGetDto> data = new List<AttanceGetDto>();

            foreach (var student in students)
            {
                AttanceGetDto attance = new AttanceGetDto
                {
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    SurName = student.SurName,
                };
                foreach (var att in attances)
                {
                    if (att.StudentId == student.Id)
                    {
                        DVMInAttanceGetDto dVMInAttanceGetDto = new DVMInAttanceGetDto
                        {
                            DVM = att.DVM
                        };
                        attance.attance.Add(dVMInAttanceGetDto);
                    }
                }
                data.Add(attance);
            }
            return Ok(data);
        }


        [HttpPut("group/{id}/{lessonId}")]
        public ActionResult<List<AttancePutDto>> GroupAttanceEdit(int id, int lessonId, List<AttancePutDto> putDtos)
        {
            var attances = _attanceRepository.GetAll(x => x.LessonId == lessonId);

            foreach (var item in putDtos)
            {
                List<Attance> attanceDatas = attances.FindAll(x => x.StudentId == item.StudentId);
                int idx = 0;
                foreach (var attItem in attanceDatas)
                {
                    Attance updateAtt = _attanceRepository.Get(x => x.Id == attItem.Id);
                    updateAtt.DVM = item.attance[idx].DVM;
                    _attanceRepository.Commit();
                    idx++;
                }
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<List<AttanceGetDtoById>> GetAttanceById(int id)
        {
            var attances = _attanceRepository.GetAll(x => x.StudentId == id);
            var lessons = _lessonRepository.GetAll(x => true);

            var result = lessons.Select(lesson =>
            {
                var attanceForLesson = attances.Where(a => a.LessonId == lesson.Id && a.StudentId == id).ToList();

                if (attanceForLesson.Count() > 0)
                {
                    return new LessonAndAttanceDto
                    {
                        Lesson = lesson,
                        Attances = attanceForLesson
                    };
                }
                return null;

            }).ToList();


            List<AttanceGetDtoById> data = new List<AttanceGetDtoById>();

            foreach (var item in result)
            {
                if (item != null)
                {
                   int groupId = _studentRepository.Get(x => x.Id == item.Attances.FirstOrDefault().StudentId).GroupId;
                   int teacherId = _groupLessonRepository.Get(x=>x.GroupId == groupId).TeacherId;
                    var teacher = _teacherRepository.Get(x => x.Id == teacherId);
                    AttanceGetDtoById getDto = new AttanceGetDtoById
                    {
                        Id = item.Lesson.Id,
                        Name = item.Lesson.Name,
                        Teacher = teacher.FirstName+" "+teacher.SurName,
                        Time = item.Attances.Count(),
                        Plus = item.Attances.FindAll(x => x.DVM == "+").Count(),
                        Absance = item.Attances.FindAll(x => x.DVM == "-").Count(),
                        Percentage = (100 / item.Attances.Count() * item.Attances.FindAll(x => x.DVM == "-").Count()),
                    };

                    data.Add(getDto);
                }
            }

            return Ok(data);
        }
    }
}

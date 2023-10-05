using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.GradeDtos;
using UniverstyTMS.Dtos.GroupDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GradeController : ControllerBase
    {
        private readonly IGradesRepository _gradesRepository;
        private readonly IMapper _mapper;

        public GradeController(IGradesRepository gradesRepository,IMapper mapper)
        {
            _gradesRepository = gradesRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create(GradePostDto postDto)
        {

            Grades grades = _mapper.Map<Grades>(postDto);

            
            int SdfGrade = ((grades.SDF1 + grades.SDF2 + grades.SDF3+grades.TSI) * 10/100)+(grades.SSI/2);
            grades.ORT = SdfGrade + 10; 
           
            _gradesRepository.Add(grades);
            _gradesRepository.Commit();

            return StatusCode(201, new { grades.Id });
        }

        [HttpGet("all")]
        public ActionResult<List<GradeGetDto>> GetAll()
        {
            var data = _mapper.Map<List<GradeGetDto>>(_gradesRepository.GetAll(x => true, "Student","Lesson"));

            return Ok(data);
        }

        [HttpPut("lesson/{id}")]
        public ActionResult Edit(int id, List<GradePutDto> putDtos)
        {
            foreach (var putDto in putDtos)
            {
                Grades grade = _gradesRepository.Get(x => x.StudentId == putDto.Id && x.LessonId == id);
                if(grade != null)
                {
                    grade.SDF1 = putDto.SDF1;
                    grade.SDF2 = putDto.SDF2;
                    grade.SDF3 = putDto.SDF3;
                    grade.SSI = putDto.SSI;
                    grade.TSI = putDto.TSI;
                    grade.ORT = ((putDto.SDF1 + putDto.SDF2 + putDto.SDF3 + putDto.TSI) * 10 / 100) + (putDto.SSI / 2) + 10;
                    _gradesRepository.Commit();
                }
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<List<GradeGetDto>> GetById(int id) 
        {
            var data = _mapper.Map<List<GradeGetDto>>(_gradesRepository.GetAll(x => x.StudentId == id, "Student", "Lesson"));

            return Ok(data);
        }
    }
}

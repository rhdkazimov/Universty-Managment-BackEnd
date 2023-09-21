using AutoMapper;
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

    }
}

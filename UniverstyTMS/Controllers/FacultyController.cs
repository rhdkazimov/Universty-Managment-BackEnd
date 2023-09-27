using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.AnnounceDtos;
using UniverstyTMS.Dtos.FacultyDtos;
using UniverstyTMS.Dtos.TypeDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public FacultyController(IFacultyRepository facultyRepository,ILessonRepository lessonRepository,IMapper mapper) {
            _facultyRepository = facultyRepository;
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create(FacultyPostDto postDto)
        {
            Faculty faculty = _mapper.Map<Faculty>(postDto);

            _facultyRepository.Add(faculty);
            _facultyRepository.Commit();
            return StatusCode(201, new { faculty.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Faculty faculty = _facultyRepository.Get(x => x.Id == id);

            if (faculty == null)
                return NotFound();

            _facultyRepository.Remove(faculty);
            _facultyRepository.Commit();

            return NoContent();
        }

        [HttpGet("all")]
        public ActionResult<List<FacultyGetDto>> GetAll()
        {
            var data = _mapper.Map<List<FacultyGetDto>>(_facultyRepository.GetAll(x => true));

            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, FacultyPutDto putDto)
        {
            Faculty faculty = _facultyRepository.Get(x => x.Id == id);

            if (faculty == null)
                return NotFound();

            faculty.Name = putDto.Name;
            faculty.Code = putDto.Code;
            _facultyRepository.Commit();

            return NoContent();
        }

        [HttpGet("programs")]
        public ActionResult<List<FacultyProgramsGetDto>> ProgramsGet()
        {

            var data = _mapper.Map<List<FacultyProgramsGetDto>>(_facultyRepository.GetAll(x=>true));
            foreach (var item in data)
            {
                var lessons = _mapper.Map<List<LessonInFacultyProgramsGetDto>>(_lessonRepository.GetAll(x => x.FacultyId == item.Id));
                if(lessons.Count > 0)
                {
                foreach (var ls in lessons)
                {
                    item.Lessons.Add(ls);
                }
                }
            }
            return Ok(data);
        }

        [HttpGet("programs/{id}")]
        public ActionResult<List<LessonInFacultyProgramsGetDto>> ProgramsGetById(int id)
        {
                var data = _mapper.Map<List<LessonInFacultyProgramsGetDto>>(_lessonRepository.GetAll(x => x.FacultyId == id));
            return Ok(data);
        }
    }
}

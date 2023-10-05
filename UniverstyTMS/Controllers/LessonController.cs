using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Dtos.LessonDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonController(ILessonRepository lessonRepository,IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public ActionResult<List<LessonGetDto>> GetAll() 
        {
            var data = _mapper.Map<List<LessonGetDto>>(_lessonRepository.GetAll(X => true));

            return Ok(data);
        }

        [HttpPost("")]
        public IActionResult Create(LessonPostDto postDto)
        {
            if (_lessonRepository.IsExist(x => x.Name == postDto.Name))
            {
                ModelState.AddModelError("Name", "This Lesson is already exist");
                return BadRequest(ModelState);
            }

            Lesson lesson = _mapper.Map<Lesson>(postDto);

            _lessonRepository.Add(lesson);
            _lessonRepository.Commit();

            return StatusCode(201, new { lesson.Id });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Lesson lesson = _lessonRepository.Get(x => x.Id == id);

            if (lesson == null)
                return NotFound();

            _lessonRepository.Remove(lesson);
            _lessonRepository.Commit();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, LessonPostDto putDto)
        {
            Lesson lesson = _lessonRepository.Get(x => x.Id == id);

            if (lesson == null)
                return NotFound();

            lesson.Name = putDto.Name;
            lesson.FacultyId = putDto.FacultyId;
            _lessonRepository.Commit();

            return NoContent();
        }
    }
}

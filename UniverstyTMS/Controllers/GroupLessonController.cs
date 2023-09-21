using AutoMapper;
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
    public class GroupLessonController : ControllerBase
    {
        private readonly IGroupLessonRepository _groupLessonRepository;
        private readonly IMapper _mapper;

        public GroupLessonController(IGroupLessonRepository groupLessonRepository,IMapper mapper)
        {
            _groupLessonRepository = groupLessonRepository;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public ActionResult<List<GroupLessonsGetDto>> GetAll()
        {
             string[] includes = { "Lesson", "Group" };

            return Ok(_mapper.Map<List<GroupLessonsGetDto>>(_groupLessonRepository.GetAll(X => true, "Lesson", "Group")));
        }

        [HttpPost("")]
        public IActionResult Create(GroupLessonsPostDto postDto)
        {
            GroupLessons groupLesson = _mapper.Map<GroupLessons>(postDto);

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

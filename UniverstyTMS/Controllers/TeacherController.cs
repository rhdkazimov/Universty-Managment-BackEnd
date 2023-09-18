using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
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
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository,IMapper mapper)
        {
            _teacherRepository = teacherRepository;
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
    }
}

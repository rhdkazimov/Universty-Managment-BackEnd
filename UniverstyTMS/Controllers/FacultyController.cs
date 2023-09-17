using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public FacultyController(IFacultyRepository facultyRepository) {
            _facultyRepository = facultyRepository;
        }

        [HttpPost("")]
        public IActionResult Create(FacultyPostDto postDto)
        {
            Faculty faculty = new Faculty
            {
                Name = postDto.Name,
                Code = postDto.Code,
            };

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
            var data = _facultyRepository.GetAllQueryable(x => true).Select(x => new FacultyGetDto { Id = x.Id, Name = x.Name, Code = x.Code });

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
    }
}

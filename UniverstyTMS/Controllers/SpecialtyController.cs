using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.SpecialtyDtos;
using UniverstyTMS.Dtos.TypeDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IFacultyRepository _facultyRepository;

        public SpecialtyController(ISpecialtyRepository specialtyRepository,IFacultyRepository facultyRepository)
        {
            _specialtyRepository = specialtyRepository;
            _facultyRepository = facultyRepository;
        }

        [HttpPost("")]
        public IActionResult Create(SpecialtyPostDto postDto)
        {
            if(_specialtyRepository.IsExist(x=>x.Name==postDto.Name))
            {
                    ModelState.AddModelError("Name", "Name is already exist");
                    return BadRequest(ModelState);
            }

            Specialty  specialty = new Specialty
            {
                Name = postDto.Name,
                FacultyId = postDto.FacultyId,
            };

            _specialtyRepository.Add(specialty);
            _specialtyRepository.Commit();

            return StatusCode(201, new { specialty.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Specialty specialty = _specialtyRepository.Get(x => x.Id == id);

            if (specialty == null)
                return NotFound();

            _specialtyRepository.Remove(specialty);
            _specialtyRepository.Commit();

            return NoContent();
        }

        [HttpGet("all")]
        public ActionResult<List<SpecialtyGetDto>> GetAll()
        {
            var data = _specialtyRepository.GetAllQueryable(x => true).Select(x => new SpecialtyGetDto { Id = x.Id, Name = x.Name,FacultyId = x.FacultyId });

            return Ok(data);
        }
    }
}

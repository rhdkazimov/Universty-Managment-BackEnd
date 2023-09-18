using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.SettingDtos;
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
        private readonly IMapper _mapper;

        public SpecialtyController(ISpecialtyRepository specialtyRepository,IFacultyRepository facultyRepository,IMapper mapper)
        {
            _specialtyRepository = specialtyRepository;
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create(SpecialtyPostDto postDto)
        {
            if(_specialtyRepository.IsExist(x=>x.Name==postDto.Name))
            {
                    ModelState.AddModelError("Name", "Name is already exist");
                    return BadRequest(ModelState);
            }

            Specialty  specialty = _mapper.Map<Specialty>(postDto);

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
            var data = _mapper.Map<List<SpecialtyGetDto>>(_specialtyRepository.GetAll(x=>true,"Faculty"));

            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<SpecialtyGetDto> Get(int id)
        {
            Specialty entity = _specialtyRepository.Get(x => x.Id == id, "Faculty");

            if (entity == null) return NotFound();

            var data = _mapper.Map<SpecialtyGetDto>(entity);

            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, SpecialtyPutDto putDto)
        {
            Specialty specialty = _specialtyRepository.Get(x => x.Id == id);

            if (specialty == null)
                return NotFound();

            specialty.FacultyId = putDto.FacultyId;
            specialty.Name = putDto.Name;

            _specialtyRepository.Commit();

            return NoContent();
        }
    }
}

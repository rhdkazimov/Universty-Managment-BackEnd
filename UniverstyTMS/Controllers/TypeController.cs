using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.SettingDtos;
using UniverstyTMS.Dtos.TypeDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TypeController : ControllerBase
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public TypeController(ITypeRepository typeRepository,IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create(TypePostDto postDto)
        {
            Core.Entities.Type type = _mapper.Map<Core.Entities.Type>(postDto);

            _typeRepository.Add(type);
            _typeRepository.Commit();

            return StatusCode(201, new { type.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Core.Entities.Type type = _typeRepository.Get(x => x.Id == id);

            if (type == null)
                return NotFound();

            _typeRepository.Remove(type);
            _typeRepository.Commit();

            return NoContent();
        }

        [HttpGet("all")]
        public ActionResult<List<TypeGetDto>> GetAll()
        {
            var data = _mapper.Map<List<TypeGetDto>>(_typeRepository.GetAll(x=>true));

            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, TypePostDto putDto)
        {
            Core.Entities.Type type = _typeRepository.Get(x => x.Id == id);

            if (type == null)
                return NotFound();

            type.Name = putDto.Name;
            _typeRepository.Commit();

            return NoContent();
        }

    }
}

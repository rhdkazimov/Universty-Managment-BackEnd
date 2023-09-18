using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Dtos.SettingDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsRepository _settingsRepository;
        private readonly IMapper _mapper;

        public SettingsController(ISettingsRepository settingsRepository, IMapper mapper)
        {
            _settingsRepository = settingsRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create(SettingPostDto postDto)
        {
            Settings settings = _mapper.Map<Settings>(postDto);

            _settingsRepository.Add(settings);
            _settingsRepository.Commit();

            return StatusCode(201, new { settings.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Settings settings = _settingsRepository.Get(x => x.Id == id);

            if (settings == null)
                return NotFound();

            _settingsRepository.Remove(settings);
            _settingsRepository.Commit();

            return NoContent();
        }

        [HttpGet("all")]
        public ActionResult<List<SettingGetDto>> GetAll()
        {
            var data = _mapper.Map<List<SettingGetDto>>(_settingsRepository.GetAll(x=>true));
            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, SettingPutDto putDto)
        {
            Settings settings = _settingsRepository.Get(x => x.Id == id);

            if (settings == null)
                return NotFound();

            settings.Key = putDto.Key;
            settings.Value = putDto.Value;
            _settingsRepository.Commit();

            return NoContent();
        }
    }
}

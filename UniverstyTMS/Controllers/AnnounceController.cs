using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data;
using UniverstyTMS.Dtos.AnnounceDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnounceController : ControllerBase
    {
        private readonly IAnnounceRepository _announceRepository;
        private readonly IMapper _mapper;

        public AnnounceController(IAnnounceRepository announceRepository,IMapper mapper)
        {
            _announceRepository = announceRepository;
            _mapper = mapper;
        }


        [HttpPost("")]
        public IActionResult Create(AnnouncePostDto postDto)
        {
            Announce announce = _mapper.Map<Announce>(postDto);
            announce.Date = DateTime.Now.ToString("dd/MM/yyyy");

            _announceRepository.Add(announce);
            _announceRepository.Commit();

            return StatusCode(201, new { announce.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            Announce announce = _announceRepository.Get(x => x.Id == id);

            if (announce == null)
                return NotFound();

            _announceRepository.Remove(announce);
            _announceRepository.Commit();

            return NoContent();
        }

        [HttpGet("all")] 
        public ActionResult<List<AnnounceGetDto>> GetAll()
        {
            var data = _mapper.Map<List<AnnounceGetDto>>(_announceRepository.GetAll(x=>true));
            return Ok(data);
        }
    }
}

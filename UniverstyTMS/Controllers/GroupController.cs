using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.GroupDtos;
using UniverstyTMS.Dtos.TeacherDtos;
using UniverstyTMS.Helper;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GroupController(IGroupRepository groupRepository,IStudentRepository studentRepository,IMapper mapper)
        {
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create( GroupPostDto postDto)
        {
            if (_groupRepository.IsExist(x => x.GroupCode == postDto.GroupCode))
            {
                ModelState.AddModelError("GroupCode", "GroupCode is already exist");
                return BadRequest(ModelState);
            }

            Group group = _mapper.Map<Group>(postDto);

            _groupRepository.Add(group);
            _groupRepository.Commit();

            return StatusCode(201, new { group.Id });
        }

        [HttpGet("all")]
        public ActionResult<List<GroupGetDto>> GetAll()
        {
            var data = _mapper.Map<List<GroupGetDto>>(_groupRepository.GetAll(x => true, "Specialty")); //,"Faculty" NOT INCLUDE ERROR 505

            foreach(var item in data)
            {
                item.StudentsCount = _studentRepository.GetAllQueryable(x=>true).Count(x=>x.GroupId == item.Id);
            }

            return Ok(data);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Group group = _groupRepository.Get(x => x.Id == id);

            if (group == null)
                return NotFound();

            _groupRepository.Remove(group);
            _groupRepository.Commit();

            return NoContent();
        }

    }
}

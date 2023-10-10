using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Dtos.GroupDtos;
using UniverstyTMS.Dtos.StatisticDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public StatisticController(IStudentRepository studentRepository,ITeacherRepository teacherRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        [HttpGet("user")]
        public ActionResult<List<GroupGetDto>> GetAll()
        {
            UserCountGetDto userCountGetDto = new UserCountGetDto
            {
                StudentsCount = _studentRepository.GetAll(x=>true).Count(),
                TeachersCount = _teacherRepository.GetAll(x=>true).Count(),
            };

            return Ok(userCountGetDto);
        }
    }
}

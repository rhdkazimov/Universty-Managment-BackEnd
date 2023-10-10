using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Dtos.AppUserDtos;
using UniverstyTMS.Dtos.StudentDtos;
using UniverstyTMS.Dtos.TeacherDtos;
using UniverstyTMS.Dtos.UserDtos;
using UniverstyTMS.Services;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;
        //usermanager<appuser> usermanager, signınmanager<appuser> signınmanager,
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, ISpecialtyRepository specialtyRepository, IGroupRepository groupRepository, ITeacherRepository teacherRepository, IStudentRepository studentRepository, ITypeRepository typeRepository, IFacultyRepository facultyRepository, IMapper mapper, JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _specialtyRepository = specialtyRepository;
            _groupRepository = groupRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
            _jwtService = jwtService;
            _typeRepository = typeRepository;
            _facultyRepository = facultyRepository;
        }

        [HttpPost("login")]
        public ActionResult<UserLoginDto> Login(UserLoginDto postDto)
        {
            Student student = _studentRepository.Get(x => x.Id == postDto.Id);
            if (student != null && student.Password == postDto.Password)
            {
                var data = _mapper.Map<StudentLoginGetDto>(student);
                data.Type = _typeRepository.Get(x => x.Id == student.TypeId).Name;
                data.Img = "https://localhost:7046/uploads/students/" + data.Img;
                int specalityId = _groupRepository.Get(x => x.Id == student.GroupId).SpecialtyId;
                var specality = _specialtyRepository.Get(x => x.Id == specalityId);
                data.Specialty = specality.Name;
                data.Faculty = _facultyRepository.Get(x => x.Id == specality.FacultyId).Name;
                return StatusCode(201, new { token = _jwtService.GenerateToken(data.Mail, data.FirstName), user = data });
            }
            Teacher teacher = _teacherRepository.Get(x => x.Id == postDto.Id);
            if (teacher != null && teacher.Password == postDto.Password)
            {
                var data = _mapper.Map<TeacherLoginGetDto>(teacher);
                data.Type = _typeRepository.Get(x => x.Id == teacher.TypeId).Name;
                data.Faculty = _facultyRepository.Get(x => x.Id == teacher.FacultyId).Name;
                data.Img = "https://localhost:7046/uploads/teachers/" + data.Img;
                return StatusCode(201, new { token = _jwtService.GenerateToken(data.Mail, data.FirstName), user = data });
            }

            return StatusCode(404, new { msg = "Sifre ve ya Id sehvdir" });
        }

        [HttpPost("admin/login")]
        public async Task<ActionResult<AdminLoginDto>> AdminLogin(AdminLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.Mail);


            if (user == null)
                return Unauthorized();

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized();

            var roles = await _userManager.GetRolesAsync(user);

            var responseData = new
            {
                token = _jwtService.GenerateToken(user,roles),
                user
            };

            //await _signInManager.SignInAsync(user, false);

            return Ok(responseData);
        }


        [HttpPost("admin/register")]
        [Authorize(Roles = "Staff")]
        public async Task<ActionResult<AdminCreateDto>> CreateAdmin(AdminCreateDto createDto)
        {
            AppUser user = new AppUser
            {
                UserName = createDto.UserName,
                Email = createDto.Mail,
                IsAdmin = true,
            };

            var isExistMail = await _userManager.FindByEmailAsync(createDto.Mail);

            if (isExistMail != null)
                return StatusCode(404,"Mail already is exist");

            var result = await _userManager.CreateAsync(user, createDto.Password);
            //await _userManager.AddToRoleAsync(user, "Staff");

            if (!result.Succeeded)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("admin/delete/{mail}")]
        [Authorize(Roles = "Staff")]
        public async Task<ActionResult> RemoveAdmin(string mail)
        {
         AppUser admin =  await _userManager.FindByEmailAsync(mail);

            if (admin == null) 
                return NotFound();

           var result = await _userManager.DeleteAsync(admin);

            if (!result.Succeeded)
                return StatusCode(400, "Something went wrong ");

            return Ok();
        }

        //[HttpGet("Role")]
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.DeleteAsync(new IdentityRole("Member"));
        //    await _roleManager.CreateAsync(new IdentityRole("Teacher"));
        //    await _roleManager.CreateAsync(new IdentityRole("Student"));
        //    //await _roleManager.CreateAsync(new IdentityRole("Admin"));

        //    return Ok();
        //}

        [HttpPost("Logout")]
        public IActionResult LogOut()
        {
            return Ok();
        }
    }
}

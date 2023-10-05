using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;
using UniverstyTMS.Data.Repositories;
using UniverstyTMS.Dtos.ContactFormDtos;
using UniverstyTMS.Dtos.FacultyDtos;

namespace UniverstyTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ContactFormController : ControllerBase
    {
        private readonly IContactFormRepository _contactFormRepository;
        private readonly IMapper _mapper;

        public ContactFormController(IContactFormRepository contactFormRepository,IMapper mapper)
        {
            _contactFormRepository = contactFormRepository;
            _mapper = mapper;
        }

        [HttpPost("")]
        public IActionResult Create(ContactFormPostDto postDto)
        {
            ContactForm contactForm = _mapper.Map<ContactForm>(postDto);

            _contactFormRepository.Add(contactForm);
            _contactFormRepository.Commit();
            return StatusCode(201, new { contactForm.Id });
        }

    }
}

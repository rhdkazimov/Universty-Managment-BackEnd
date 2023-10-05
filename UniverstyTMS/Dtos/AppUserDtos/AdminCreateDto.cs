using FluentValidation;
using UniverstyTMS.Dtos.AttanceDtos;

namespace UniverstyTMS.Dtos.AppUserDtos
{
    public class AdminCreateDto
    {
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }

    public class AdminCreateDtoValidator : AbstractValidator<AdminCreateDto>
    {
        public AdminCreateDtoValidator()
        {

            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Mail).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}

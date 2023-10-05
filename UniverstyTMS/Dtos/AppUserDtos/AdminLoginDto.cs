using FluentValidation;

namespace UniverstyTMS.Dtos.AppUserDtos
{
    public class AdminLoginDto
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }

    public class AdminLoginDtoValidator : AbstractValidator<AdminLoginDto>
    {
        public AdminLoginDtoValidator()
        {

            RuleFor(x => x.Mail).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}

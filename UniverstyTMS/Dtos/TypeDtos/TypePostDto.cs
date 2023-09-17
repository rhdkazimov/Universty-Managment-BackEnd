using FluentValidation;
using UniverstyTMS.Dtos.SettingDtos;

namespace UniverstyTMS.Dtos.TypeDtos
{
    public class TypePostDto
    {
        public string Name { get; set; }
    }

    public class TypePostDtoValidator : AbstractValidator<TypePostDto>
    {
        public TypePostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}

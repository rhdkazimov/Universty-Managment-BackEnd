using FluentValidation;
using UniverstyTMS.Dtos.TypeDtos;

namespace UniverstyTMS.Dtos.FacultyDtos
{
    public class FacultyPostDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class FacultyPostDtoValidator : AbstractValidator<FacultyPostDto>
    {
        public FacultyPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        }
    }
}

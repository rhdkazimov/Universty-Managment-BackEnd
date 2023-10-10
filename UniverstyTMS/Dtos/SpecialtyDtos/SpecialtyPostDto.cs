using FluentValidation;
using UniverstyTMS.Dtos.TypeDtos;

namespace UniverstyTMS.Dtos.SpecialtyDtos
{
    public class SpecialtyPostDto
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }
    }   

    public class SpecialtyPostDtoValidator : AbstractValidator<SpecialtyPostDto>
    {
        public SpecialtyPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.FacultyId).NotEmpty();
        }
    }
}

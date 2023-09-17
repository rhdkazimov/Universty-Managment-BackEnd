using FluentValidation;

namespace UniverstyTMS.Dtos.SpecialtyDtos
{
    public class SpecialtyPutDto
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }
    }

    public class SpecialtyPutDtoValidator : AbstractValidator<SpecialtyPutDto>
    {
        public SpecialtyPutDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.FacultyId).NotEmpty();
        }
    }
}

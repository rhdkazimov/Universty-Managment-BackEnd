using FluentValidation;

namespace UniverstyTMS.Dtos.FacultyDtos
{
    public class FacultyPutDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class FacultyPutDtoValidator : AbstractValidator<FacultyPutDto>
    {
        public FacultyPutDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        }
    }
}

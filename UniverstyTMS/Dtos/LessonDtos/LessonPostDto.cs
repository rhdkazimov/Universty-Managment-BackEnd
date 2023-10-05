using FluentValidation;

namespace UniverstyTMS.Dtos.LessonDtos
{
    public class LessonPostDto
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
    }

    public class LessonPostDtoValidator : AbstractValidator<LessonPostDto>
    {
        public LessonPostDtoValidator()
        {
            RuleFor(x => x.FacultyId).NotEmpty();
            RuleFor(x => x.Hours).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(1);
        }
    }
}
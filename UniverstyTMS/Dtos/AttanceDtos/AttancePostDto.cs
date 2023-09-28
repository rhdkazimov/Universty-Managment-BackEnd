using FluentValidation;
using UniverstyTMS.Dtos.AnnounceDtos;

namespace UniverstyTMS.Dtos.AttanceDtos
{
    public class AttancePostDto
    {
        public int StudentId { get; set; }
        public int LessonId { get; set; }
    }

    public class AttancePostDtoValidator : AbstractValidator<AttancePostDto>
    {
        public AttancePostDtoValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty();
        }
    }
}

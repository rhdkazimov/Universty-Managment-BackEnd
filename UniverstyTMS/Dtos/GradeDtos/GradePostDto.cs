using FluentValidation;
using UniverstyTMS.Dtos.GroupDtos;

namespace UniverstyTMS.Dtos.GradeDtos
{
    public class GradePostDto
    {
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public int SDF1 { get; set; } = 0;
        public int SDF2 { get; set; } = 0;
        public int SDF3 { get; set; } = 0;
        public int TSI { get; set; } = 0;
        public int SSI { get; set; } = 0;
    }

    public class GradePostDtoValidator : AbstractValidator<GradePostDto>
    {
        public GradePostDtoValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty();
            RuleFor(x => x.SDF1).NotEmpty();
            RuleFor(x => x.SDF2).NotEmpty();
            RuleFor(x => x.SDF3).NotEmpty();
            RuleFor(x => x.TSI).NotEmpty();
            RuleFor(x => x.SSI).NotEmpty();
        }
    }
}

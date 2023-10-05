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

            RuleFor(x => x).Custom((x, content) =>
            {
                if (x.SDF1 < 0 || x.SDF1 > 100)
                {
                    content.AddFailure(nameof(x.SDF1), "SDF1 should be between 0 and 100 ");
                }
            });
            RuleFor(x => x).Custom((x, content) =>
            {
                if (x.SDF2 < 0 || x.SDF2 > 100)
                {
                    content.AddFailure(nameof(x.SDF2), "SDF2 should be between 0 and 100 ");
                }
            });
            RuleFor(x => x).Custom((x, content) =>
            {
                if (x.SDF3 < 0 || x.SDF3 > 100)
                {
                    content.AddFailure(nameof(x.SDF3), "SDF3 should be between 0 and 100 ");
                }
            });
            RuleFor(x => x).Custom((x, content) =>
            {
                if (x.TSI < 0 || x.TSI > 100)
                {
                    content.AddFailure(nameof(x.TSI), "TSI should be between 0 and 100 ");
                }
            });
            RuleFor(x => x).Custom((x, content) =>
            {
                if (x.SSI < 0 || x.SSI > 100)
                {
                    content.AddFailure(nameof(x.SSI), "SSI should be between 0 and 100 ");
                }
            });
        }
    }
}

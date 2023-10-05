using FluentValidation;
using UniverstyTMS.Dtos.SpecialtyDtos;

namespace UniverstyTMS.Dtos.StudentDtos
{
    public class StudentPostDto
    {
        public int GroupId { get; set; }
        public int TypeId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Birthday { get; set; }
        public string Mail { get; set; }
        public string Language { get; set; }
        public int IncludeYear { get; set; }
        public int PerYear { get; set; }
        public bool Status { get; set; }
        public int IncludePoint { get; set; }
        public bool StateOrdered { get; set; }
        public IFormFile ImgFile { get; set; }
    }

    public class StudentPostDtoValidator : AbstractValidator<StudentPostDto>
    {
        public StudentPostDtoValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.SurName).NotEmpty();
            RuleFor(x => x.Birthday).NotEmpty();
            RuleFor(x => x.Mail).NotEmpty();
            RuleFor(x => x.Language).NotEmpty();
            RuleFor(x => x.IncludeYear).NotEmpty();
            RuleFor(x => x.PerYear).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.IncludePoint).NotEmpty();
            RuleFor(x => x.ImgFile).NotEmpty();

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.ImgFile != null)
                {
                    if (x.ImgFile.Length > 5242880)
                        context.AddFailure(nameof(x.ImgFile), "ImageFile must be less or equal than 5MB");

                    if (x.ImgFile.ContentType != "image/jpeg" && x.ImgFile.ContentType != "image/png")
                        context.AddFailure(nameof(x.ImgFile), "ImageFile must be image/jpeg or image/png");
                }
            });
            RuleFor(x => x).Custom((x, content) =>
            {
                if (x.IncludePoint < 0 || x.IncludePoint > 700)
                {
                    content.AddFailure(nameof(x.IncludePoint), "IncludePoint should be between 0 and 700 ");
                }
            });
        }
    }
}

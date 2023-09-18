using FluentValidation;
using UniverstyTMS.Dtos.SpecialtyDtos;

namespace UniverstyTMS.Dtos.TeacherDtos
{
    public class TeacherPostDto
    {
        public int FacultyId { get; set; }
        public int TypeId { get; set; }
        public int IncludedYear { get; set; }
        public string Language { get; set; }
        public string Specialty { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Birthday { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public IFormFile ImageFile { get; set; }
    }

    public class TeacherPostDtoValidator : AbstractValidator<TeacherPostDto>
    {
        public TeacherPostDtoValidator()
        {
            RuleFor(x => x.FacultyId).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty();
            RuleFor(x => x.IncludedYear).NotEmpty();
            RuleFor(x => x.Language).NotEmpty();
            RuleFor(x => x.Specialty).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.SurName).NotEmpty();
            RuleFor(x => x.Birthday).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Mail).NotEmpty();
            RuleFor(x => x.ImageFile).NotNull();

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.ImageFile != null)
                {
                    if (x.ImageFile.Length > 5242880)
                        context.AddFailure(nameof(x.ImageFile), "ImageFile must be less or equal than 5MB");

                    if (x.ImageFile.ContentType != "image/jpeg" && x.ImageFile.ContentType != "image/png")
                        context.AddFailure(nameof(x.ImageFile), "ImageFile must be image/jpeg or image/png");
                }

            });
        }
    }
}

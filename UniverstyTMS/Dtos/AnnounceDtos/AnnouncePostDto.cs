using FluentValidation;

namespace UniverstyTMS.Dtos.AnnounceDtos
{
    public class AnnouncePostDto
    {
        public string HeaderInfo { get; set; }
        public string MainInfo { get; set; }
    }

    public class AnnouncePostDtoValidator : AbstractValidator<AnnouncePostDto>
    {
        public AnnouncePostDtoValidator() {
            RuleFor(x => x.HeaderInfo).NotEmpty().MaximumLength(30).WithMessage("Maksimum Xarakter Sayi 30dur");
            RuleFor(x => x.HeaderInfo).NotEmpty().MinimumLength(1);
        }
    }
}

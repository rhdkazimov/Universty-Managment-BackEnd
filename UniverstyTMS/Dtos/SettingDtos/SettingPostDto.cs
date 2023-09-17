using FluentValidation;
using UniverstyTMS.Dtos.AnnounceDtos;

namespace UniverstyTMS.Dtos.SettingDtos
{
    public class SettingPostDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class SettingPostDtoValidator : AbstractValidator<SettingPostDto>
    {
        public SettingPostDtoValidator()
        {
            RuleFor(x => x.Key).NotEmpty().MaximumLength(30).WithMessage("Maksimum Xarakter Sayi 30dur");
            RuleFor(x => x.Value).NotEmpty().MinimumLength(1);
        }
    }
}

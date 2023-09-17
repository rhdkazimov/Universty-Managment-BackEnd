using FluentValidation;

namespace UniverstyTMS.Dtos.SettingDtos
{
    public class SettingPutDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class SettingPutDtoValidator : AbstractValidator<SettingPutDto>
    {
        public SettingPutDtoValidator()
        {
            RuleFor(x => x.Key).NotEmpty().MaximumLength(30).WithMessage("Maksimum Xarakter Sayi 30dur");
            RuleFor(x => x.Value).NotEmpty().MinimumLength(1);
        }
    }
}

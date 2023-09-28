using FluentValidation;
using UniverstyTMS.Dtos.GroupDtos;

namespace UniverstyTMS.Dtos.ContactFormDtos
{
    public class ContactFormPostDto
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public string Contact { get; set; }
    }

    public class ContactFormPostDtoValidator : AbstractValidator<ContactFormPostDto>
    {
        public ContactFormPostDtoValidator()
        {
            RuleFor(x => x.Header).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Text).NotEmpty();
        }
    }
}

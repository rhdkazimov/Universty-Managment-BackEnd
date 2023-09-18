using FluentValidation;
using UniverstyTMS.Dtos.FacultyDtos;

namespace UniverstyTMS.Dtos.GroupDtos
{
    public class GroupPostDto
    {
        public string GroupCode { get; set; }
        public int SpecialtyId { get; set; }

    }

    public class GroupPostDtoValidator : AbstractValidator<GroupPostDto>
    {
        public GroupPostDtoValidator()
        {
            RuleFor(x => x.GroupCode).NotEmpty().MaximumLength(20);
            RuleFor(x => x.SpecialtyId).NotEmpty();
        }
    }
}

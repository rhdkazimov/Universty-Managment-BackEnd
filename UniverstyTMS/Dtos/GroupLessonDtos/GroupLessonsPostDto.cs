using FluentValidation;
using UniverstyTMS.Dtos.LessonDtos;

namespace UniverstyTMS.Dtos.GroupLessonDtos
{
    public class GroupLessonsPostDto
    {
        public int GroupId { get; set; }
        public int LessonId { get; set; }
    }

    public class GroupLessonsPostDtoValidator : AbstractValidator<GroupLessonsPostDto>
    {
        public GroupLessonsPostDtoValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty();
            RuleFor(x => x.LessonId).NotEmpty();
        }
    }
}

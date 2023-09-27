using FluentValidation;

namespace UniverstyTMS.Dtos.GradeDtos
{
    public class GradePutDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int SDF1 { get; set; }
        public int SDF2 { get; set; }
        public int SDF3 { get; set; }
        public int TSI { get; set; }
        public int SSI { get; set; }
        public int ORT { get; set; }
    }

    public class GradePutDtoValidator : AbstractValidator<GradePutDto>
    {
        public GradePutDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.SurName).NotEmpty();
            RuleFor(x => x.SDF1).NotEmpty();
            RuleFor(x => x.SDF2).NotEmpty();
            RuleFor(x => x.SDF3).NotEmpty();
            RuleFor(x => x.TSI).NotEmpty();
            RuleFor(x => x.SSI).NotEmpty();
            RuleFor(x => x.ORT).NotEmpty();
        }
    }
}

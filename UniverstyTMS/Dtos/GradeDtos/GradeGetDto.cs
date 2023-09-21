namespace UniverstyTMS.Dtos.GradeDtos
{
    public class GradeGetDto
    {
        public int Id { get; set; }
        public StudentInGradeGetDto Student { get; set; }
        public LessonInGradeGetDto Lesson { get; set; }
        public int SDF1 { get; set; } = 0;
        public int SDF2 { get; set; } = 0;
        public int SDF3 { get; set; } = 0;
        public int TSI { get; set; } = 0;
        public int SSI { get; set; } = 0;
        public int ORT { get; set; } = 0;
    }

    public class StudentInGradeGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }

    public class LessonInGradeGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

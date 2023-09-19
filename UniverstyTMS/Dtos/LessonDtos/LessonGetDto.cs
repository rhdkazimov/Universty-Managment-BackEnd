namespace UniverstyTMS.Dtos.LessonDtos
{
    public class LessonGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FacultyInLessonGetDto Faculty { get; set; }
    }

    public class FacultyInLessonGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

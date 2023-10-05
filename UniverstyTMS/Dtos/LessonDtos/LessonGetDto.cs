namespace UniverstyTMS.Dtos.LessonDtos
{
    public class LessonGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int FacultyId { get; set; }
    }
}

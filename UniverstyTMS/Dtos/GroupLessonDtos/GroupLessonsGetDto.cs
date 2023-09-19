namespace UniverstyTMS.Dtos.GroupLessonDtos
{
    public class GroupLessonsGetDto
    {
        public int Id { get; set; }
        //public GroupInGroupLessonGetDto Group { get; set; }
        //public LessonInGroupLessonGetDto Lesson { get; set; }
    }

    public class GroupInGroupLessonGetDto {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public int SpecialtyId { get; set; }
    }
    public class LessonInGroupLessonGetDto {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public string Name { get; set; }
    }

}

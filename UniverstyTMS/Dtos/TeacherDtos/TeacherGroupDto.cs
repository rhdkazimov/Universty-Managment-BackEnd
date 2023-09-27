namespace UniverstyTMS.Dtos.TeacherDtos
{
    public class TeacherGroupDto
    {
       public int Id { get; set; }
        public GroupInTeacherGroupDto Group { get; set; }
        //public int TeacherId { get; set; }
        public LessonInTeacherGroupDto Lesson { get; set; }
    }

    public class GroupInTeacherGroupDto
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public int StudentsCount { get; set; }
    }

    public class LessonInTeacherGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

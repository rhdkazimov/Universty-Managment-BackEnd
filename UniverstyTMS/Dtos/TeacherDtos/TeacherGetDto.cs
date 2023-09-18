namespace UniverstyTMS.Dtos.TeacherDtos
{
    public class TeacherGetDto
    {
        public int Id { get; set; }
        public int IncludedYear { get; set; }
        public string Language { get; set; }
        public string Specialty { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Birthday { get; set; }
        public string Mail { get; set; }
        public string Img { get; set; }
        public FacultyInTeacherGetDto Faculty { get; set; }
        public TypeInTeacherGetDto Type { get; set; }
    }

    public class TypeInTeacherGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FacultyInTeacherGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

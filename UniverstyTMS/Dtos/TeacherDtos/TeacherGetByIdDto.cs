using UniverstyTMS.Core.Entities;

namespace UniverstyTMS.Dtos.TeacherDtos
{
    public class TeacherGetByIdDto
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
        public FacultyInTeacherGetByIdDto Faculty { get; set; }
        public TypeInTeacherGetByIdDto Type { get; set; }
    }

    public class TypeInTeacherGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FacultyInTeacherGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

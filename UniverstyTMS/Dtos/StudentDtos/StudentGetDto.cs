namespace UniverstyTMS.Dtos.StudentDtos
{
    public class StudentGetDto
    {
        public GroupInStudentGetDto Group { get; set; }
        public TypeInStudentGetDto Type { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Birthday { get; set; }
        public string Mail { get; set; }
        public string Language { get; set; }
        public int IncludeYear { get; set; }
        public int PerYear { get; set; }
        public bool Status { get; set; }
        public int IncludePoint { get; set; }
        public bool StateOrdered { get; set; }
        public string Img { get; set; }
    }

    public class TypeInStudentGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GroupInStudentGetDto
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public int SpecialtyId { get; set; }
    }
}

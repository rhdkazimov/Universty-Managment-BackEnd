namespace UniverstyTMS.Dtos.TeacherDtos
{
    public class TeacherLoginGetDto
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
        public string Faculty { get; set; }
        public string Type { get; set; }
    }
}

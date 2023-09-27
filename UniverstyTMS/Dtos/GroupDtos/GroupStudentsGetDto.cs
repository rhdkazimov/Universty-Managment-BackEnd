using UniverstyTMS.Core.Entities;

namespace UniverstyTMS.Dtos.GroupDtos
{
    public class GroupStudentsGetDto
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public List<StudentInGroupGetDto> Students { get; set; } = new List<StudentInGroupGetDto>();
    }

    public class StudentInGroupGetDto
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
}

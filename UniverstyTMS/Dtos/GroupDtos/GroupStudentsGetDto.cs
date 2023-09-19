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
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
}

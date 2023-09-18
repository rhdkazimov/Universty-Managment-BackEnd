using UniverstyTMS.Core.Entities;
using static UniverstyTMS.Dtos.GroupDtos.StudentsInGroupGetDto;

namespace UniverstyTMS.Dtos.GroupDtos
{
    public class GroupGetDto
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public int StudentsCount { get; set; }
        public SpecialtyInGroupGetDto Specialty { get; set; }
        //public List<StudentsInGroupGetDto> Students { get; set; }
    }
    public class SpecialtyInGroupGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        //public FacultyInGroupGetDto Faculty { get; set; }
    }

    public class StudentsInGroupGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
    public class FacultyInGroupGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

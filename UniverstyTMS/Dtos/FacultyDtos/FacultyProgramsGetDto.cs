using UniverstyTMS.Core.Entities;

namespace UniverstyTMS.Dtos.FacultyDtos
{
    public class FacultyProgramsGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<LessonInFacultyProgramsGetDto> Lessons { get; set; } = new List<LessonInFacultyProgramsGetDto>();
    }

    public class LessonInFacultyProgramsGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

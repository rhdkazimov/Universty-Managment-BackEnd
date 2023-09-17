
namespace UniverstyTMS.Dtos.SpecialtyDtos
{
    public class SpecialtyGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        //public FacultyInSpecialtyGetDto Faculty { get; set; }
    }

    public class FacultyInSpecialtyGetDto
    {
        public string Name { get; set; }
    }
}

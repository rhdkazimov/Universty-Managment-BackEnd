
namespace UniverstyTMS.Core.Entities
{
    public class Group
    {
        public int Id { get; set; } 
        public string GroupCode { get; set; }
        //public int TeacherId { get; set; }
        public int SpecialtyId { get; set; }


        public Specialty Specialty { get; set; }
        //public Teacher Teacher { get; set;}
        public List<Student> Students { get; set; } = new List<Student>();
    }
}

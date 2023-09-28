using UniverstyTMS.Core.Entities;

namespace UniverstyTMS.Dtos.AttanceDtos
{
    public class LessonAndAttanceDto
    {
        public Lesson Lesson { get; set; }
        public List<Attance> Attances { get; set; } = new List<Attance>();
    }
}

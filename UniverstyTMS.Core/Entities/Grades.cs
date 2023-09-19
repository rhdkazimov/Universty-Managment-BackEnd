using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverstyTMS.Core.Entities
{
    public class Grades
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public int SDF1 { get; set; } = 0;
        public int SDF2 { get; set; } = 0;
        public int SDF3 { get; set; } = 0;
        public int TSI { get; set; } = 0;
        public int SSI { get; set; } = 0;
        public int ORT { get; set; } = 0;

        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}

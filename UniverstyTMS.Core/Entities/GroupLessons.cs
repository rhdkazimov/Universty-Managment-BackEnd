using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverstyTMS.Core.Entities
{
    public class GroupLessons
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int LessonId { get; set; }
        public Group Group { get; set; }
        public Lesson Lesson { get; set; }
    }
}

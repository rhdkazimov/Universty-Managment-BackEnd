using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverstyTMS.Core.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public string Name { get; set; }
    }
}

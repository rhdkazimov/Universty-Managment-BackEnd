using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverstyTMS.Core.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public int TypeId { get; set; }
        public int IncludedYear { get; set; }
        public string Language { get; set; }
        public string Specialty { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Birthday { get; set; } 
        public string Password { get; set; }    
        public string Mail { get; set; }
        public string Img { get; set; }

        public Type Type { get; set; }
        public Faculty Faculty { get; set; }
        public List<Group> Groups { get; set; }
    }
}

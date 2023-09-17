using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverstyTMS.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int TypeId { get;set; } 
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Birthday { get; set; }
        public string Mail { get; set; }
        public string Language { get; set; }
        public int IncludeYear { get; set; }
        public int PerYear { get; set; }
        public bool Status { get; set; }
        public int IncludePoint { get; set; }
        public bool StateOrdered { get; set; }
        public string Img { get; set; }

        public Group Group { get; set; }
        public Type Type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverstyTMS.Core.Entities
{
    public class Announce
    {
        public int Id { get; set; }
        public string HeaderInfo { get; set; }
        public string MainInfo { get; set; }
        public string Date { get; set; }
    }
}

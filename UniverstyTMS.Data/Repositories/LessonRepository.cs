using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Core.Repositories;

namespace UniverstyTMS.Data.Repositories
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(UniverstyDbContext context) : base(context)
        {
        }
    }
}

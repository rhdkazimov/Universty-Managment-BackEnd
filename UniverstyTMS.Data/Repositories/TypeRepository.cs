using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverstyTMS.Core.Repositories;

namespace UniverstyTMS.Data.Repositories
{
    public class TypeRepository : Repository<Core.Entities.Type>, ITypeRepository
    {
        public TypeRepository(UniverstyDbContext context) : base(context)
        {
        }
    }
}

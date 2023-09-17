using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverstyTMS.Core.Entities;

namespace UniverstyTMS.Data.Configurations
{
    public class GroupConfigration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(x => x.GroupCode).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.SpecialtyId).IsRequired(true);
            //builder.Property(x => x.TeacherId).IsRequired(true); 
        }
    }
}

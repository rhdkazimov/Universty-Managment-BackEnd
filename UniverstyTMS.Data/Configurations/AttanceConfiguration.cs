using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverstyTMS.Core.Entities;

namespace UniverstyTMS.Data.Configurations
{
    public class AttanceConfiguration : IEntityTypeConfiguration<Attance>
    {
        public void Configure(EntityTypeBuilder<Attance> builder)
        {
            builder.Property(x => x.StudentId).IsRequired(true);
            builder.Property(x => x.LessonId).IsRequired(true);
            builder.Property(x => x.DVM).HasDefaultValue("-");
        }
    }
}

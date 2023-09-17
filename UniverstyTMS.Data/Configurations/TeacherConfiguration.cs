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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.FacultyId).IsRequired();
            builder.Property(x => x.Specialty).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.SurName).IsRequired();
            builder.Property(x => x.Language).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.IncludedYear).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.Img).IsRequired();
            builder.Property(x => x.Mail).IsRequired();
        }
    }
}

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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.GroupId).IsRequired();
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.SurName).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.Mail).IsRequired();
            builder.Property(x => x.StateOrdered).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.PerYear).IsRequired();
            builder.Property(x => x.IncludePoint).IsRequired();
            builder.Property(x => x.IncludeYear).IsRequired();
            builder.Property(x => x.Img).IsRequired();
            builder.Property(x => x.Language).IsRequired();
        }
    }
}

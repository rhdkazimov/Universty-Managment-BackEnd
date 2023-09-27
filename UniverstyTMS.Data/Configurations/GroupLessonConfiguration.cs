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
    public class GroupLessonConfiguration : IEntityTypeConfiguration<GroupLessons>
    {
        public void Configure(EntityTypeBuilder<GroupLessons> builder)
        {
            builder.Property(x => x.GroupId).IsRequired(true);
            builder.Property(x => x.LessonId).IsRequired(true);
            builder.HasOne(x=>x.Teacher).WithMany(x=>x.GroupLessons).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

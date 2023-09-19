using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniverstyTMS.Core.Entities;

namespace UniverstyTMS.Data.Configurations
{
    public class GradesConfigration : IEntityTypeConfiguration<Grades>
    {
        public void Configure(EntityTypeBuilder<Grades> builder)
        {
            builder.Property(x => x.SDF1).IsRequired(true);
            builder.Property(x => x.SDF2).IsRequired(true);
            builder.Property(x => x.SDF3).IsRequired(true);
            builder.Property(x => x.SSI).IsRequired(true);
            builder.Property(x => x.TSI).IsRequired(true);
            builder.Property(x => x.ORT).IsRequired(true);
            builder.Property(x => x.LessonId).IsRequired(true);
            builder.Property(x => x.StudentId).IsRequired(true);
        }
    }
}

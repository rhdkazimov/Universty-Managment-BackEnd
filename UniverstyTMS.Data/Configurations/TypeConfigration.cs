using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniverstyTMS.Data.Configurations
{
    public class TypeConfigration : IEntityTypeConfiguration<Core.Entities.Type>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Type> builder)
        {
            builder.Property(x => x.Name).IsRequired();
        }
    }
}

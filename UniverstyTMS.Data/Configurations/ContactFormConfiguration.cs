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
    public class ContactFormConfiguration : IEntityTypeConfiguration<ContactForm>
    {
        public void Configure(EntityTypeBuilder<ContactForm> builder)
        {
            builder.Property(x => x.Header).IsRequired(true);
            builder.Property(x => x.Text).IsRequired(true);
        }
    }
}

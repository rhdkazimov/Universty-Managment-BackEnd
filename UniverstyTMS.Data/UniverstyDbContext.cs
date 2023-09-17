using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Data.Configurations;

namespace UniverstyTMS.Data
{
    public class UniverstyDbContext:DbContext
    {
        public UniverstyDbContext(DbContextOptions<UniverstyDbContext> options):base(options)
        {
        }

        public DbSet<Announce> Announces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnnounceConfigration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

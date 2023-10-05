using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniverstyTMS.Core.Entities;
using UniverstyTMS.Data.Configurations;

namespace UniverstyTMS.Data
{
    public class UniverstyDbContext:IdentityDbContext
    {
        public UniverstyDbContext(DbContextOptions<UniverstyDbContext> options):base(options)
        {
        }

        public DbSet<Announce> Announces { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Core.Entities.Type> Types { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<GroupLessons> GroupLessons { get; set; }
        public DbSet<Attance> Attances { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnnounceConfigration).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}

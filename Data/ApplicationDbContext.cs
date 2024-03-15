using Clarity_Crate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clarity_Crate.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Curriculum> Curriculum { get; set; } = default!;

        public DbSet<Subject> Subject { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //there is a many to many relationship between subject and curriculum
            //it should cascade on delete
            builder.Entity<Subject>()
                .HasMany(s => s.Curriculums)
                .WithMany(c => c.Subjects)
                .UsingEntity(j => j.ToTable("CurriculumSubject"));


        }
    }
}

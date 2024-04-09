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

        public DbSet<Topic> Topic { get; set; } = default!;

        public DbSet<Term> Term { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //there is a many to many relationship between subject and topic
            //it should cascade on delete
            builder.Entity<Subject>()
                .HasMany(s => s.Curriculums)
                .WithMany(c => c.Subjects)
                .UsingEntity(j => j.ToTable("CurriculumSubject"));


            //there is a many to many relationship between subject and topic
            builder.Entity<Topic>()
               .HasMany(t => t.Subjects)
               .WithMany(s => s.Topics)
               .UsingEntity(j => j.ToTable("TopicSubject"));



            //there is a one-many relationship between definition and topic
            builder.Entity<Definition>()
                .HasOne(d => d.Topic)
                .WithMany(t => t.Definitions)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            //there is a one-many relationship between definition and curriculum
            builder.Entity<Definition>()
                .HasOne(d => d.Curriculum)
                .WithMany(c => c.Definitions)
                .HasForeignKey(d => d.CurriculumId)
                .OnDelete(DeleteBehavior.Cascade);

            //there is a one-many relationship between definition and subject
            builder.Entity<Definition>()
                .HasOne(d => d.Subject)
                .WithMany(s => s.Definitions)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);


            //there is a one-many relationship between definition and term
            builder.Entity<Definition>()
                .HasOne(d => d.Term)
                .WithMany(t => t.Definitions)
                .HasForeignKey(d => d.TermId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

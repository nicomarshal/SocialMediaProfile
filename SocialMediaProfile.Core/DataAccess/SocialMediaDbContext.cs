using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.Core.Entities;

namespace SocialMediaProfile.Core.DataAccess
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
               .HasOne(x => x.Role)
               .WithMany(y => y.Users)
               .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<Experience>()
               .HasOne(x => x.Person)
               .WithMany(y => y.Experiencies)
               .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Education>()
               .HasOne(x => x.Person)
               .WithMany(y => y.Educations)
               .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Skill>()
               .HasOne(x => x.Person)
               .WithMany(y => y.Skills)
               .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Skill>()
               .HasOne(x => x.Person)
               .WithMany(y => y.Skills)
               .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Project>()
               .HasOne(x => x.Person)
               .WithMany(y => y.Projects)
               .HasForeignKey(x => x.PersonId);

            modelBuilder.SeedRoles();
            modelBuilder.SeedUsers();
            modelBuilder.SeedExperiences();
            //    modelBuilder.SeedTransactions();
        }
    }
}

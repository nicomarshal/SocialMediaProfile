using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess.Entities;

namespace SocialMediaProfile.DataAccess
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

            modelBuilder.Entity<User>() //OneToOne
                .HasOne(x => x.Person)
                .WithOne(y => y.User)
                .HasForeignKey<Person>(x => x.UserId);

            modelBuilder.Entity<User>() //OneToMany
               .HasOne(x => x.Role)
               .WithMany(y => y.Users)
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.ClientSetNull);   

            modelBuilder.Entity<Experience>() //OneToMany
               .HasOne(x => x.Person)
               .WithMany(y => y.Experiencies)
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Education>() //OneToMany
               .HasOne(x => x.Person)
               .WithMany(y => y.Educations)
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Skill>() //OneToMany
               .HasOne(x => x.Person)
               .WithMany(y => y.Skills)
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Project>() //OneToMany
               .HasOne(x => x.Person)
               .WithMany(y => y.Projects)
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.SeedRoles();
            modelBuilder.SeedUsers();
            modelBuilder.SeedPeople();
            modelBuilder.SeedExperiences();
            modelBuilder.SeedEducations();
            modelBuilder.SeedSkills();
            modelBuilder.SeedProjects();
        }
    }
}

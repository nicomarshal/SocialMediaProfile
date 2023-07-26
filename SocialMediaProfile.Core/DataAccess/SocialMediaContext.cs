using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.Core.Entities;

namespace SocialMediaProfile.Core.DataAccess
{
    public class SocialMediaContext : DbContext
    {
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
        : base(options)
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
            //    base.OnModelCreating(modelBuilder);

            //    modelBuilder.Entity<Transaction>()
            //        .HasKey(t => new { t.Id });

            //    modelBuilder.Entity<Transaction>()
            //        .HasOne(x => x.User)
            //        .WithMany()
            //        .HasForeignKey(x => x.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);

            //    modelBuilder.Entity<Transaction>()
            //        .HasOne(x => x.Account)
            //        .WithMany()
            //        .HasForeignKey(x => x.AccountId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);

            //    modelBuilder.Entity<Transaction>()
            //        .HasOne(x => x.ToAccount)
            //        .WithMany()
            //        .HasForeignKey(x => x.ToAccountId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);

            //    modelBuilder.SeedRoles();
            //    modelBuilder.SeedUsers();
            //    modelBuilder.SeedAccounts();
            //    modelBuilder.SeedTransactions();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.DataAccess
{
    public static class SocialMediaSeeds
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", Description = "Usuario Administrador" },
                new Role { Id = 2, Name = "Regular", Description = "Usuario Regular" }
                );
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Gian123", Password = "gian123", Email = "gianledesma@gmail.com", RoleId = 1 },
                new User { Id = 2, Username = "Nico123", Password = "nico123", Email = "nicoledesma@gmail.com", RoleId = 2 }
                );
        }

        public static void SeedPeople(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, ProfileImg = "imgGian", Name = "Gian", Surname = "Ledesma", Profession = "Matemàtico", AboutMe = "Simpàtico y curioso", UserId = 1 },
                new Person { Id = 2, ProfileImg = "imgNico", Name = "Nicolàs", Surname = "Ledesma", Profession = "Desarrollador", AboutMe = "Mùsico y curioso", UserId = 2 }
                );
        }

        public static void SeedExperiences(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>().HasData(
                new Experience { Id = 1, Logo = "imgGian", Name = "CONICET", Job = "Cientìfico", StartDate = DateTime.Now, FinishDate = DateTime.Now, Description = "Centro de investigaciòn nacional", PersonId = 1 },
                new Experience { Id = 2, Logo = "imgNico", Name = "eFALCOM", Job = "Desarrollador .NET", StartDate = DateTime.Now, FinishDate = DateTime.Now, Description = "Automatizaciones industriales", PersonId = 2 }
                );
        }
    }
}

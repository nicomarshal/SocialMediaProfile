using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.DataAccess
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
                new Experience { Id = 1, Logo = "imgExpGian", Name = "CONICET", Job = "Cientìfico", StartDate = DateTime.Now, FinishDate = DateTime.Now, Description = "Centro de investigaciòn nacional", PersonId = 1 },
                new Experience { Id = 2, Logo = "imgExpNico", Name = "eFALCOM", Job = "Desarrollador .NET", StartDate = DateTime.Now, FinishDate = DateTime.Now, Description = "Automatizaciones industriales", PersonId = 2 }
                );
        }

        public static void SeedEducations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>().HasData(
                new Education { Id = 1, Logo = "imgEducGian", Name = "FAMAF - UNC", Description = "Carrera universitaria de 5 años", Career = "Licenciatura en Matemática", StartDate = DateTime.Now, FinishDate = DateTime.Now, PersonId = 1 },
                new Education { Id = 2, Logo = "imgEducNico", Name = "FCEFyN - UNC", Description = "Carrera universitaria de 5 años", Career = "Ingenierìa en Computaciòn", StartDate = DateTime.Now, FinishDate = DateTime.Now, PersonId = 2 }
                );
        }

        public static void SeedSkills(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "imgSKGian", Percentage = 95, PersonId = 1 },
                new Skill { Id = 2, Name = "imgSkNico", Percentage = 95, PersonId = 2 }
                );
        }

        public static void SeedProjects(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Robot 3D", Description = "Robot construido con bloques", StartDate = DateTime.Now, FinishDate = DateTime.Now, Images = "ImagesGian", URL = "https://", PersonId = 1 },
                new Project { Id = 2, Name = "ChatApp", Description = "App de mensajerìa", StartDate = DateTime.Now, FinishDate = DateTime.Now, Images = "ImagesNico", URL = "https://", PersonId = 2 }
                );
        }
    }
}

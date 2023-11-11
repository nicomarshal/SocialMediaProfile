using SocialMediaProfile.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Role> RoleRepository { get; }
        UserRepository UserRepository { get; }
        IGenericRepository<Person> PersonRepository { get; }
        IGenericRepository<Education> EducationRepository { get; }
        ExperienceRepository ExperienceRepository { get; }
        IGenericRepository<Project> ProjectRepository { get; }
        IGenericRepository<Skill> SkillRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

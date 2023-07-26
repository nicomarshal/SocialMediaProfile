using SocialMediaProfile.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Person> PersonRepository { get; }
        IGenericRepository<Education> EducationRepository { get; }
        IGenericRepository<Experience> ExperiencieRepository { get; }
        IGenericRepository<Project> ProjectRepository { get; }
        IGenericRepository<Skill> SkillRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

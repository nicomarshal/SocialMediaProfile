using SocialMediaProfile.DataAccess.Entities;

namespace SocialMediaProfile.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Role> RoleRepository { get; }
        UserRepository UserRepository { get; }
        PersonRepository PersonRepository { get; }
        EducationRepository EducationRepository { get; }
        ExperienceRepository ExperienceRepository { get; }
        ProjectRepository ProjectRepository { get; }
        IGenericRepository<Skill> SkillRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

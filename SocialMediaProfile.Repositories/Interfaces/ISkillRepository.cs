using SocialMediaProfile.Core.Entities;

namespace SocialMediaProfile.Repositories.Interfaces
{
    public interface ISkillRepository : IGenericRepository<Skill>
    {
        Task<IEnumerable<Skill>> GetAllByAliasAsync(string alias);
    }
}

using SocialMediaProfile.Core.Entities;

namespace SocialMediaProfile.Repositories.Interfaces
{
    public interface IExperienceRepository : IGenericRepository<Experience>
    {
        Task<IEnumerable<Experience>> GetAllByAliasAsync(string alias);
    }
}

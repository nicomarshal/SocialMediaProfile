using SocialMediaProfile.Core.Entities;

namespace SocialMediaProfile.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        public interface IProjectRepository : IGenericRepository<Project>
        {
            Task<IEnumerable<Project>> GetAllByAliasAsync(string alias);
        }
    }
}

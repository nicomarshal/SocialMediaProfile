using SocialMediaProfile.Core.Entities;

namespace SocialMediaProfile.Repositories.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<Person> GetByAliasAsync(string alias);
    }
}

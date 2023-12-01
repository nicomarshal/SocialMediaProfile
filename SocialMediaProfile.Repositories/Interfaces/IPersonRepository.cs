using SocialMediaProfile.DataAccess.Entities;

namespace SocialMediaProfile.Repositories.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<IEnumerable<Person>> GetAllByAliasAsync(string alias);
    }
}

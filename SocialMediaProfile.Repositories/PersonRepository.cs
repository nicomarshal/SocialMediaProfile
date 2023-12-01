using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.DataAccess.Entities;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Person>> GetAllByAliasAsync(string alias)
        {
            return await _entities.Include(u => u.User).Where(v => v.User.Alias == alias).ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.DataAccess.Entities;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        public ExperienceRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
        }

        public Task AddAsync(Experience entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Experience entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Experience>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Experience>> GetAllByAliasAsync(string alias)
        {
            return await _entities.Include(u => u.User).Where(v => v.User.Alias == alias).ToListAsync();
        }

        public Task<Experience> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Experience entity)
        {
            throw new NotImplementedException();
        }
    }
}

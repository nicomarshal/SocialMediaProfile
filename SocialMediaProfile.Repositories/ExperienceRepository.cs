using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class ExperienceRepository : GenericRepository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Experience>> GetAllInDescOrderAsync()
        {
            var result = await GetAllAsync();
            result = result.OrderByDescending(t => t.StartDate).ToList();

            return result;
        }

        public async Task<IEnumerable<Experience>> GetAllInDescOrderAsync(string alias)
        {
            var result = await _entities.Include(u => u.User).Where(v => v.User.Alias == alias).ToListAsync();
            result = result.OrderByDescending(t => t.StartDate).ToList();
            
            return result;
        }
    }
}

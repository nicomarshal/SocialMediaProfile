using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Project>> GetAllInDescOrderAsync()
        {
            var result = await GetAllAsync();
            result = result.OrderByDescending(t => t.StartDate).ToList();

            return result;
        }

        public async Task<IEnumerable<Project>> GetAllInDescOrderAsync(string alias)
        {
            var result = await _entities.Include(u => u.User).Where(v => v.User.Alias == alias).ToListAsync();
            result = result.OrderByDescending(t => t.StartDate).ToList();

            return result;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Skill>> GetAllByAliasAsync(string alias)
        {
            return await _entities.Include(u => u.User).Where(v => v.User.Alias == alias).ToListAsync();
        }
    }
}

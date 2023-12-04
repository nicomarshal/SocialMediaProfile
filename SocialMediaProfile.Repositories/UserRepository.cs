using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.DataAccess.Entities;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllWithRoleAsync()
        {
            return await _entities.Include(u => u.Role).ToListAsync();
        }
    }
}

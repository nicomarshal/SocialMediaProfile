﻿using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<string>> GetAllAliasAsync()
        { 
            return await _entities.Select(u => u.Alias).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllWithRoleAsync()
        {
            return await _entities.Include(u => u.Role).ToListAsync();
        }

        public async Task<User> GetByAliasAsync(string alias)
        {
            return await _entities.Where(v => v.Alias == alias).FirstOrDefaultAsync();
        }
    }
}

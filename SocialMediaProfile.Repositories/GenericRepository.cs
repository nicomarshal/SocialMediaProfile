using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SocialMediaDbContext _dbContext;
        protected readonly DbSet<T> _entities;

        public GenericRepository(SocialMediaDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        //public async Task<bool> SoftDelete(int id)
        //{
        //    try
        //    {
        //        var entity = await _entities.FindAsync(id);
        //        if (entity == null || entity.IsDeleted)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            entity.IsDeleted = true;

        //            _entities.Update(entity);
        //            return true;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error on Repository.Delete", e);
        //    }
        //}
    }
}

using Microsoft.EntityFrameworkCore;
using SocialMediaProfile.DataAccess;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaDbContext _dbContext;

        private readonly Dictionary<Type, object> Repositories;

        public UnitOfWork(SocialMediaDbContext dbContext)
        {
            _dbContext = dbContext;

            Repositories = new Dictionary<Type, object>();
            Repositories[typeof(Role)] = new GenericRepository<Role>(_dbContext);
            Repositories[typeof(User)] = new UserRepository(_dbContext);
            Repositories[typeof(Person)] = new PersonRepository(_dbContext);
            Repositories[typeof(Experience)] = new ExperienceRepository(_dbContext);
            Repositories[typeof(Education)] = new EducationRepository(_dbContext);
            Repositories[typeof(Project)] = new ProjectRepository(_dbContext);
            Repositories[typeof(Skill)] = new GenericRepository<Skill>(_dbContext);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        public object GetRepository<TEntity>() where TEntity : class
        {
            return Repositories[typeof(TEntity)];
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

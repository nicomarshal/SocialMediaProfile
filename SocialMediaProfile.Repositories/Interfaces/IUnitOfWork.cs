using SocialMediaProfile.DataAccess.Entities;

namespace SocialMediaProfile.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {
        object GetRepository<TRepository>() where TRepository : class;

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

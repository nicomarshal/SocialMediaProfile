using SocialMediaProfile.DataAccess;
using SocialMediaProfile.DataAccess.Entities;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaDbContext _dbContext;

        private readonly IGenericRepository<Role> _roleRepository;
        private readonly UserRepository _userRepository;
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IGenericRepository<Education> _educationRepository;
        private readonly IGenericRepository<Experience> _experienceRepository;
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly IGenericRepository<Skill> _skillRepository;

        public UnitOfWork(SocialMediaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Role> RoleRepository =>
            _roleRepository ?? new GenericRepository<Role>(_dbContext);

        public UserRepository UserRepository =>
            _userRepository ?? new UserRepository(_dbContext);

        public IGenericRepository<Person> PersonRepository =>
            _personRepository ?? new GenericRepository<Person>(_dbContext);

        public IGenericRepository<Education> EducationRepository =>
            _educationRepository ?? new GenericRepository<Education>(_dbContext);

        public IGenericRepository<Experience> ExperienceRepository =>
            _experienceRepository ?? new GenericRepository<Experience>(_dbContext);

        public IGenericRepository<Project> ProjectRepository =>
            _projectRepository ?? new GenericRepository<Project>(_dbContext);

        public IGenericRepository<Skill> SkillRepository =>
            _skillRepository ?? new GenericRepository<Skill>(_dbContext);


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

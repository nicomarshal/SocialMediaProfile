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
        private readonly PersonRepository _personRepository;
        private readonly EducationRepository _educationRepository;
        private readonly ExperienceRepository _experienceRepository;
        private readonly ProjectRepository _projectRepository;
        private readonly IGenericRepository<Skill> _skillRepository;

        public UnitOfWork(SocialMediaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Role> RoleRepository =>
            _roleRepository ?? new GenericRepository<Role>(_dbContext);

        public UserRepository UserRepository =>
            _userRepository ?? new UserRepository(_dbContext);

        public PersonRepository PersonRepository =>
            _personRepository ?? new PersonRepository(_dbContext);

        public EducationRepository EducationRepository =>
            _educationRepository ?? new EducationRepository(_dbContext);

        public ExperienceRepository ExperienceRepository =>
            _experienceRepository ?? new ExperienceRepository(_dbContext);

        public ProjectRepository ProjectRepository =>
            _projectRepository ?? new ProjectRepository(_dbContext);

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

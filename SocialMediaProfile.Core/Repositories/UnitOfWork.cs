using SocialMediaProfile.Core.DataAccess;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _dbContext;

        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IGenericRepository<Education> _educationRepository;
        private readonly IGenericRepository<Experience> _experiencieRepository;
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly IGenericRepository<Skill> _skillRepository;

        public UnitOfWork(SocialMediaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Role> RoleRepository =>
            _roleRepository ?? new GenericRepository<Role>(_dbContext);

        public IGenericRepository<User> UserRepository =>
            _userRepository ?? new GenericRepository<User>(_dbContext);

        public IGenericRepository<Person> PersonRepository =>
            _personRepository ?? new GenericRepository<Person>(_dbContext);

        public IGenericRepository<Education> EducationRepository =>
            _educationRepository ?? new GenericRepository<Education>(_dbContext);

        public IGenericRepository<Experience> ExperiencieRepository =>
            _experiencieRepository ?? new GenericRepository<Experience>(_dbContext);

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

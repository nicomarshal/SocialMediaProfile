using SocialMediaProfile.Core.Services.Interfaces;
using SocialMediaProfile.DataAccess.Entities;
using SocialMediaProfile.Repositories;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Core.Services
{
    public class GenericService<TEntity, TDTO, TResponseDTO> : IGenericService<TEntity, TDTO, TResponseDTO>
        where TEntity : class
        where TDTO : class
        where TResponseDTO : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private dynamic _repository;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            switch (typeof(TEntity).Name)
            {
                //case nameof(Role):
                //    _repository = (RoleRepository)_unitOfWork.GetRepository<Role>();
                //    break;
                case nameof(User):
                    _repository = (UserRepository)_unitOfWork.GetRepository<User>();
                    break;
                case nameof(Person):
                    _repository = (PersonRepository)_unitOfWork.GetRepository<Person>();
                    break;
                case nameof(Experience):
                    _repository = (ExperienceRepository)_unitOfWork.GetRepository<Experience>();
                    break;
                case nameof(Education):
                    _repository = (EducationRepository)_unitOfWork.GetRepository<Education>();
                    break;
                case nameof(Project):
                    _repository = (ProjectRepository)_unitOfWork.GetRepository<Project>();
                    break;
                //case nameof(Skill):
                //    _repository = (SkillRepository)_unitOfWork.GetRepository<Skill>();
                //    break;
                default:
                    break;
            }
        }

        public async Task<List<TDTO>> GetAllAsync()
        {
            try
            {
                var result = new List<TDTO>();

                var response = await _repository.GetAllAsync();

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(Mapper<T, TDTO>.MapToDTO(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<TDTO>> GetAllByAliasAsync(string alias)
        {
            try
            {
                var result = new List<TDTO>();

                var response = await _repository.GetAllByAliasAsync(alias);

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(Mapper<T, TDTO>.MapToDTO(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TDTO> GetByIdAsync(int id)
        {
            try
            {
                TDTO result;

                var response = await _repository.GetByIdAsync(id);

                if (response is null)
                {
                    result = Activator.CreateInstance<TDTO>();
                    return result;
                }

                result = Mapper<T, TDTO>.MapToDTO(response);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TResponseDTO> AddAsync(TDTO dto)
        {
            try
            {
                TResponseDTO result;

                if (dto is null)
                {
                    result = Activator.CreateInstance<TResponseDTO>();
                    return result;
                }

                var entity = Mapper<TDTO, T>.MapToEntity(dto);

                await _repository.AddAsync(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0;
                result = Activator.CreateInstance<TResponseDTO>();
                result.GetType().GetProperty("IsOk").SetValue(result, isOk);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TResponseDTO> UpdateAsync(int id, TDTO dto)
        {
            try
            {
                TResponseDTO result;

                if (id <= 0 || dto is null)
                {
                    result = Activator.CreateInstance<TResponseDTO>();
                    return result;
                }

                var entity = await _repository.GetByIdAsync(id);

                if (entity is null)
                {
                    result = Activator.CreateInstance<TResponseDTO>();
                    return result;
                }

                entity = Mapper<TDTO, T>.MapToEntity(dto, entity);

                _repository.Update(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0;
                result = Activator.CreateInstance<TResponseDTO>();
                result.GetType().GetProperty("IsOk").SetValue(result, isOk);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TResponseDTO> DeleteAsync(int id)
        {
            try
            {
                TResponseDTO result;

                if (id <= 0)
                {
                    result = Activator.CreateInstance<TResponseDTO>();
                    return result;
                }

                var entity = await _repository.GetByIdAsync(id);

                if (entity is null)
                {
                    result = Activator.CreateInstance<TResponseDTO>();
                    return result;
                }

                _repository.Delete(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0;
                result = Activator.CreateInstance<TResponseDTO>();
                result.GetType().GetProperty("IsOk").SetValue(result, isOk);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
    

}

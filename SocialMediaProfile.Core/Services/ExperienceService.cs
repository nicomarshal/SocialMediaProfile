using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Services.Interfaces;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Core.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExperienceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ExperienceDTO>> GetAllAsync()
        {
            try
            {
                var result = new List<ExperienceDTO>();

                var response = await _unitOfWork.ExperienceRepository.GetAllAsync();
                response = response.OrderByDescending(t => t.StartDate);

                foreach (var item in response)
                {
                    result.Add(ExperienceMapper.ExperienceToExperienceDTO(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ExperienceDTO>> GetAllByAliasAsync(string alias)
        {
            try
            {
                var result = new List<ExperienceDTO>();

                var response = await _unitOfWork.ExperienceRepository.GetAllByAliasAsync(alias);
                response = response.OrderByDescending(t => t.StartDate);

                foreach (var item in response)
                {
                    result.Add(ExperienceMapper.ExperienceToExperienceDTO(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ExperienceDTO> GetByIdAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = new ExperienceDTO();

                    var response = await _unitOfWork.ExperienceRepository.GetByIdAsync(id);

                    if (response is not null)
                    {
                        result = ExperienceMapper.ExperienceToExperienceDTO(response);
                        return result;
                    }

                    return null;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ExperienceResponseDTO> AddAsync(ExperienceDTO experienceDTO)
        {
            try
            {
                var entity = ExperienceMapper.ExperienceDTOToExperience(experienceDTO);

                await _unitOfWork.ExperienceRepository.AddAsync(entity);

                var isCreated = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;

                var result = new ExperienceResponseDTO() { IsCreated = isCreated };
          
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateAsync(int id, ExperienceDTO experienceDTO)
        {
            try
            {
                if (id > 0 && experienceDTO is not null)
                {
                    var entity = await _unitOfWork.ExperienceRepository.GetByIdAsync(id);
                    
                    if (entity is not null)
                    {
                        entity = ExperienceMapper.ExperienceDTOToExperience(experienceDTO, entity);

                        _unitOfWork.ExperienceRepository.Update(entity);

                        var result = await _unitOfWork.SaveChangesAsync();

                        if (result > 0) return true;
                        return false;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var entity = await _unitOfWork.ExperienceRepository.GetByIdAsync(id);

                    if (entity is not null)
                    {
                        _unitOfWork.ExperienceRepository.Delete(entity);

                        var result = await _unitOfWork.SaveChangesAsync();

                        if (result > 0) return true;
                        return false;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Services.Interfaces;
using SocialMediaProfile.DataAccess.Entities;
using SocialMediaProfile.Repositories;
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

                var response = (ExperienceRepository)_unitOfWork.GetRepository<Experience>();
                var res = await response.GetAllAsync();
                res = res.OrderByDescending(t => t.StartDate);

                if (response is null)
                {
                    return result;
                }

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

                var response = await _unitOfWork.Repository<ExperienceRepository>().GetAllByAliasAsync(alias);
                response = response.OrderByDescending(t => t.StartDate);

                if (response is null)
                {
                    return result;
                }

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
                ExperienceDTO result;

                var response = await _unitOfWork.Repository<ExperienceRepository>().GetByIdAsync(id);

                if (response is null)
                {
                    result = new ExperienceDTO();
                    return result;
                }

                result = ExperienceMapper.ExperienceToExperienceDTO(response);
                return result;
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
                ExperienceResponseDTO result;

                if (experienceDTO is null)
                {
                    result = new ExperienceResponseDTO() { IsOk = false };
                    return result;
                }

                var entity = ExperienceMapper.ExperienceDTOToExperience(experienceDTO);
                
                await _unitOfWork.Repository<ExperienceRepository>().AddAsync(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;               
                result = new ExperienceResponseDTO() { IsOk = isOk };  
                
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ExperienceResponseDTO> UpdateAsync(int id, ExperienceDTO experienceDTO)
        {
            try
            {
                ExperienceResponseDTO result;

                if (id <= 0 || experienceDTO is null)
                {
                    result = new ExperienceResponseDTO() { IsOk = false };
                    return result;
                }

                var entity = await _unitOfWork.Repository<ExperienceRepository>().GetByIdAsync(id);

                if (entity is null)
                {
                    result = new ExperienceResponseDTO() { IsOk = false };
                    return result;
                }

                entity = ExperienceMapper.ExperienceDTOToExperience(experienceDTO, entity);
                
                _unitOfWork.Repository<ExperienceRepository>().Update(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;              
                result = new ExperienceResponseDTO() { IsOk = isOk };

                return result; 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ExperienceResponseDTO> DeleteAsync(int id)
        {
            try
            {
                ExperienceResponseDTO result;

                if (id <= 0)
                {
                    result = new ExperienceResponseDTO() { IsOk = false };
                    return result;
                }

                var entity = await _unitOfWork.Repository<ExperienceRepository>().GetByIdAsync(id);

                if (entity is null)
                {
                    result = new ExperienceResponseDTO() { IsOk = false };
                    return result;
                }

                _unitOfWork.Repository<ExperienceRepository>().Delete(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
                result = new ExperienceResponseDTO() { IsOk = isOk };

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

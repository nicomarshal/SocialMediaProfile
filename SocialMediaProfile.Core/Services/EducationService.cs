using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Services.Interfaces;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Core.Services
{
    public class EducationService : IEducationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<EducationDTO>> GetAllAsync()
        {
            try
            {
                var result = new List<EducationDTO>();

                var response = await _unitOfWork.EducationRepository.GetAllAsync();
                response = response.OrderByDescending(t => t.StartDate);

                foreach (var item in response)
                {
                    result.Add(EducationMapper.EducationToEducationDTO(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<EducationDTO>> GetAllByAliasAsync(string alias)
        {
            try
            {
                var result = new List<EducationDTO>();

                var response = await _unitOfWork.EducationRepository.GetAllByAliasAsync(alias);
                response = response.OrderByDescending(t => t.StartDate);

                foreach (var item in response)
                {
                    result.Add(EducationMapper.EducationToEducationDTO(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EducationDTO> GetByIdAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = new EducationDTO();

                    var response = await _unitOfWork.EducationRepository.GetByIdAsync(id);

                    if (response is not null)
                    {
                        result = EducationMapper.EducationToEducationDTO(response);
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

        public async Task<EducationResponseDTO> AddAsync(EducationDTO educationDTO)
        {
            try
            {
                var entity = EducationMapper.EducationDTOToEducation(educationDTO);

                await _unitOfWork.EducationRepository.AddAsync(entity);

                var isCreated = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;

                var result = new EducationResponseDTO() { IsCreated = isCreated };

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateAsync(int id, EducationDTO educationDTO)
        {
            try
            {
                if (id > 0 && educationDTO != null)
                {
                    var entity = await _unitOfWork.EducationRepository.GetByIdAsync(id);

                    if (entity is not null)
                    {
                        entity = EducationMapper.EducationDTOToEducation(educationDTO, entity);

                        _unitOfWork.EducationRepository.Update(entity);

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
                    var entity = await _unitOfWork.EducationRepository.GetByIdAsync(id);

                    if (entity is not null)
                    {
                        _unitOfWork.EducationRepository.Delete(entity);

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

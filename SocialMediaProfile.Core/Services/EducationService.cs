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

                if (response is null)
                {
                    return result;
                }

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

                if (response is null)
                {
                    return result;
                }

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
                EducationDTO result;

                var response = await _unitOfWork.EducationRepository.GetByIdAsync(id);

                if (response is null)
                {
                    result = new EducationDTO();
                    return result;
                }

                result = EducationMapper.EducationToEducationDTO(response);
                return result;
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
                EducationResponseDTO result;

                if (educationDTO is null)
                {
                    result = new EducationResponseDTO() { IsOk = false };
                    return result;
                }

                var entity = EducationMapper.EducationDTOToEducation(educationDTO);

                await _unitOfWork.EducationRepository.AddAsync(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;

                result = new EducationResponseDTO() { IsOk = isOk };

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EducationResponseDTO> UpdateAsync(int id, EducationDTO educationDTO)
        {
            try
            {
                EducationResponseDTO result;

                if (id <= 0 || educationDTO is null)
                {
                    result = new EducationResponseDTO() { IsOk = false };
                    return result;
                }

                var entity = await _unitOfWork.EducationRepository.GetByIdAsync(id);

                if (entity is not null)
                {
                    result = new EducationResponseDTO() { IsOk = false };
                    return result;
                }

                entity = EducationMapper.EducationDTOToEducation(educationDTO, entity);

                _unitOfWork.EducationRepository.Update(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
                result = new EducationResponseDTO() { IsOk = isOk };

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EducationResponseDTO> DeleteAsync(int id)
        {
            try
            {
                EducationResponseDTO result;

                if (id <= 0)
                {
                    result = new EducationResponseDTO() { IsOk = false };
                    return result;
                }

                var entity = await _unitOfWork.EducationRepository.GetByIdAsync(id);

                if (entity is null)
                {
                    result = new EducationResponseDTO() { IsOk = false };
                    return result;
                }

                _unitOfWork.EducationRepository.Delete(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
                result = new EducationResponseDTO() { IsOk = isOk };

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

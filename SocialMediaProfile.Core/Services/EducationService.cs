using SocialMediaProfile.Core.DTOs;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Core.Repositories.Interfaces;
using SocialMediaProfile.Core.Services.Interfaces;

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
                List<EducationDTO> educationsDTO = new List<EducationDTO>();

                IEnumerable<Education> educations = await _unitOfWork.EducationRepository.GetAllAsync();
                IEnumerable<Education> result = educations.OrderByDescending(t => t.StartDate);

                foreach (Education education in result)
                {
                    educationsDTO.Add(EducationMapper.EducationToEducationDTO(education));
                }

                return educationsDTO;
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
                    EducationDTO educationDTO = new EducationDTO();

                    Education education = await _unitOfWork.EducationRepository.GetByIdAsync(id);

                    if (education != null)
                    {
                        educationDTO = EducationMapper.EducationToEducationDTO(education);
                        return educationDTO;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AddAsync(EducationDTO educationDTO)
        {
            try
            {
                if (educationDTO != null)
                {
                    Education education = EducationMapper.EducationDTOToEducation(educationDTO);

                    await _unitOfWork.EducationRepository.AddAsync(education);

                    int response = await _unitOfWork.SaveChangesAsync();

                    if (response > 0) return true;
                    else return false;
                }
                return false;
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
                    Education education = await _unitOfWork.EducationRepository.GetByIdAsync(id);
                    if (education != null)
                    {
                        education = EducationMapper.EducationDTOToEducation(educationDTO, education);

                        _unitOfWork.EducationRepository.Update(education);

                        int response = await _unitOfWork.SaveChangesAsync();

                        if (response > 0) return true;
                        else return false;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    Education education = await _unitOfWork.EducationRepository.GetByIdAsync(id);

                    if (education != null)
                    {
                        _unitOfWork.EducationRepository.Delete(education);

                        int response = await _unitOfWork.SaveChangesAsync();

                        if (response > 0) return true;
                        else return false;
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

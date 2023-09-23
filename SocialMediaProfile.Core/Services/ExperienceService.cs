using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;
using SocialMediaProfile.DataAccess.Entities;
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
                List<ExperienceDTO> experiencesDTO = new List<ExperienceDTO>();

                IEnumerable<Experience> experiences = await _unitOfWork.ExperienceRepository.GetAllAsync();
                IEnumerable<Experience> result = experiences.OrderByDescending(t => t.StartDate);

                foreach (Experience experience in result)
                {
                    experiencesDTO.Add(ExperienceMapper.ExperienceToExperienceDTO(experience));
                }

                return experiencesDTO;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<ExperienceDTO?> GetByIdAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    ExperienceDTO experienceDTO = new ExperienceDTO();

                    Experience? experience = await _unitOfWork.ExperienceRepository.GetByIdAsync(id);

                    if (experience != null)
                    {
                        experienceDTO = ExperienceMapper.ExperienceToExperienceDTO(experience);
                        return experienceDTO;
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

        public async Task<bool> AddAsync(ExperienceDTO experienceDTO)
        {
            try
            {
                if (experienceDTO != null)
                {
                    Experience experience = ExperienceMapper.ExperienceDTOToExperience(experienceDTO);

                    await _unitOfWork.ExperienceRepository.AddAsync(experience);

                    int response = await _unitOfWork.SaveChangesAsync();

                    if (response > 0) return true;
                    return false;
                }
                return false;
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
                if (id > 0 && experienceDTO != null)
                {
                    Experience? experience = await _unitOfWork.ExperienceRepository.GetByIdAsync(id);
                    if (experience != null)
                    {
                        experience = ExperienceMapper.ExperienceDTOToExperience(experienceDTO, experience);

                        _unitOfWork.ExperienceRepository.Update(experience);

                        int response = await _unitOfWork.SaveChangesAsync();

                        if (response > 0) return true;
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    Experience? experience = await _unitOfWork.ExperienceRepository.GetByIdAsync(id);

                    if (experience != null)
                    {
                        _unitOfWork.ExperienceRepository.Delete(experience);

                        int response = await _unitOfWork.SaveChangesAsync();

                        if (response > 0) return true;
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

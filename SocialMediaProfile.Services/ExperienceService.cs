using AutoMapper;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Services.Interfaces;

namespace SocialMediaProfile.Services
{
    public class ExperienceService : GenericService<Experience, ExperienceDTO, ExperienceResponseDTO>, IExperienceService
    {
        public ExperienceService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<List<ExperienceDTO>> GetAllInDescOrderAsync()
        {
            try
            {
                var result = new List<ExperienceDTO>();

                var response = await _repository.GetAllInDescOrderAsync();

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(_mapper.Map<ExperienceDTO>(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ExperienceDTO>> GetAllInDescOrderAsync(string alias)
        {
            try
            {
                var result = new List<ExperienceDTO>();

                var response = await _repository.GetAllInDescOrderAsync(alias);

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(_mapper.Map<ExperienceDTO>(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Services.Interfaces;
using AutoMapper;

namespace SocialMediaProfile.Services
{
    public class EducationService : GenericService<Education, EducationDTO, EducationResponseDTO>, IEducationService
    {
        public EducationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) 
        {
        }

        public async Task<List<EducationDTO>> GetAllInDescOrderAsync()
        {
            try
            {
                var result = new List<EducationDTO>();

                var response = await _repository.GetAllInDescOrderAsync();

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(_mapper.Map<EducationDTO>(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<EducationDTO>> GetAllInDescOrderAsync(string alias)
        {
            try
            {
                var result = new List<EducationDTO>();

                var response = await _repository.GetAllInDescOrderAsync(alias);

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(_mapper.Map<EducationDTO>(item));
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

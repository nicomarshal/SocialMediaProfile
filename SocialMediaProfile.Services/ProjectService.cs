using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services.Interfaces;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Core.Entities;
using AutoMapper;

namespace SocialMediaProfile.Services
{
    public class ProjectService : GenericService<Project, ProjectDTO, ProjectResponseDTO>, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<List<ProjectDTO>> GetAllInDescOrderAsync()
        {
            try
            {
                var result = new List<ProjectDTO>();

                var response = await _repository.GetAllInDescOrderAsync();

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(_mapper.Map<ProjectDTO>(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ProjectDTO>> GetAllInDescOrderAsync(string alias)
        {
            try
            {
                var result = new List<ProjectDTO>();

                var response = await _repository.GetAllInDescOrderAsync(alias);

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(_mapper.Map<ProjectDTO>(item));
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

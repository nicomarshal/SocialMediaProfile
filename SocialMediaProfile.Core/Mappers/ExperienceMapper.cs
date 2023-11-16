using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.DataAccess.Entities;

namespace SocialMediaProfile.Core.Mappers
{
    public class ExperienceMapper
    {
        public static ExperienceDTO ExperienceToExperienceDTO(Experience experience)
        {
            ExperienceDTO experienceDTO = new ExperienceDTO()
            {
                Id = experience.Id,
                Logo = experience.Logo,
                Name = experience.Name,
                Job = experience.Job,
                StartDate = experience.StartDate,
                FinishDate = experience.FinishDate,
                Description = experience.Description,
                UserId = experience.UserId
            };
            return experienceDTO;
        }

        public static Experience ExperienceDTOToExperience(ExperienceDTO experienceDTO)
        {
            Experience experience = new Experience()
            {
                Logo = experienceDTO.Logo,
                Name = experienceDTO.Name,
                Job = experienceDTO.Job,
                StartDate = experienceDTO.StartDate,
                FinishDate = experienceDTO.FinishDate,
                Description = experienceDTO.Description,
                UserId = experienceDTO.UserId
            };
            return experience;
        }

        public static Experience ExperienceDTOToExperience(ExperienceDTO experienceDTO, Experience experience)
        {
            experience.Id = experienceDTO.Id;
            experience.Logo = experienceDTO.Logo;
            experience.Name = experienceDTO.Name;
            experience.Job = experienceDTO.Job;
            experience.StartDate = experienceDTO.StartDate;
            experience.FinishDate = experienceDTO.FinishDate;
            experience.Description = experienceDTO.Description;
            experience.UserId = experienceDTO.UserId;

            return experience;
        }
    }
}

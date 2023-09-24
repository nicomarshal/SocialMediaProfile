using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Mappers
{
    public class ExperienceMapper
    {
        public static ExperienceDTO ExperienceToExperienceDTO(Experience experience)
        {
            ExperienceDTO experienceDTO = new ExperienceDTO()
            {
                Logo = experience.Logo,
                Name = experience.Name,
                Job = experience.Job,
                StartDate = experience.StartDate,
                FinishDate = experience.FinishDate,
                Description = experience.Description,
                PersonId = experience.PersonId
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
                PersonId = experienceDTO.PersonId
            };
            return experience;
        }

        public static Experience ExperienceDTOToExperience(ExperienceDTO experienceDTO, Experience experience)
        {
            experience.Logo = experienceDTO.Logo;
            experience.Name = experienceDTO.Name;
            experience.Job = experienceDTO.Job;
            experience.StartDate = experienceDTO.StartDate;
            experience.FinishDate = experienceDTO.FinishDate;
            experience.Description = experienceDTO.Description;
            experience.PersonId = experienceDTO.PersonId;

            return experience;
        }
    }
}

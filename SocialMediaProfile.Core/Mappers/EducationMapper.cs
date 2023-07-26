using SocialMediaProfile.Core.DTOs;
using SocialMediaProfile.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Mappers
{
    public static class EducationMapper
    {
        public static EducationDTO EducationToEducationDTO(Education education)
        {
            EducationDTO educationDTO = new EducationDTO()
            {
                Logo = education.Logo,
                Name = education.Name,
                Description = education.Description,
                Career = education.Career,
                StartDate = education.StartDate,
                FinishDate = education.FinishDate
            };
            return educationDTO;
        }

        public static Education EducationDTOToEducation(EducationDTO educationDTO)
        {
            Education education = new Education()
            {
                Logo = educationDTO.Logo,
                Name = educationDTO.Name,
                Description = educationDTO.Description,
                Career = educationDTO.Career,
                StartDate = educationDTO.StartDate,
                FinishDate = educationDTO.FinishDate
            };
            return education;
        }

        public static Education EducationDTOToEducation(EducationDTO educationDTO, Education education)
        {
            education.Logo = educationDTO.Logo;
            education.Name = educationDTO.Name;
            education.Description = educationDTO.Description;
            education.Career = educationDTO.Career;
            education.StartDate = educationDTO.StartDate;
            education.FinishDate = educationDTO.FinishDate;

            return education;
        }
    }
}

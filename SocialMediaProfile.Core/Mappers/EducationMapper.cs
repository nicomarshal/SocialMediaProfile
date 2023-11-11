using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.DataAccess.Entities;

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
                FinishDate = education.FinishDate,
                UserId = education.UserId
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
                FinishDate = educationDTO.FinishDate,
                UserId = educationDTO.UserId
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
            education.UserId = educationDTO.UserId;

            return education;
        }
    }
}

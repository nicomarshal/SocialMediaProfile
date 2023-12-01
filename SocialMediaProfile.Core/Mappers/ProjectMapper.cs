using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.DataAccess.Entities;

namespace SocialMediaProfile.Core.Mappers
{
    public class ProjectMapper
    {
        public static ProjectDTO ProjectToProjectDTO(Project project)
        {
            ProjectDTO projectDTO = new ProjectDTO()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                FinishDate = project.FinishDate,
                Images = project.Images,
                URL = project.URL,
                UserId = project.UserId
            };
            return projectDTO;
        }

        public static Project ProjectDTOToProject(ProjectDTO projectDTO)
        {
            Project project = new Project()
            {
                Id = projectDTO.Id,
                Name = projectDTO.Name,
                Description = projectDTO.Description,
                StartDate = projectDTO.StartDate,
                FinishDate = projectDTO.FinishDate,
                Images = projectDTO.Images,
                URL = projectDTO.URL,
                UserId = projectDTO.UserId
            };
            return project;
        }

        public static Project ProjectDTOToProject(ProjectDTO projectDTO, Project project)
        {
            project.Id = projectDTO.Id;
            project.Name = projectDTO.Name;
            project.Description = projectDTO.Description;
            project.StartDate = projectDTO.StartDate;
            project.FinishDate = projectDTO.FinishDate;
            project.Images = projectDTO.Images;
            project.URL = projectDTO.URL;
            project.UserId = projectDTO.UserId;

            return project;
        }
    }
}

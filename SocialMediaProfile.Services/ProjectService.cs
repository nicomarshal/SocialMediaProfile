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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<List<ProjectDTO>> GetAllAsync()
        //{
        //    try
        //    {
        //        var result = new List<ProjectDTO>();

        //        var response = await _unitOfWork.Repository<ProjectRepository>().GetAllAsync();
        //        response = response.OrderByDescending(t => t.StartDate);

        //        if (response is null)
        //        {
        //            return result;
        //        }

        //        foreach (var item in response)
        //        {
        //            result.Add(ProjectMapper.ProjectToProjectDTO(item));
        //        }

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<List<ProjectDTO>> GetAllByAliasAsync(string alias)
        //{
        //    try
        //    {
        //        var result = new List<ProjectDTO>();

        //        var response = await _unitOfWork.Repository<ProjectRepository>().GetAllByAliasAsync(alias);
        //        response = response.OrderByDescending(t => t.StartDate);

        //        if (response is null)
        //        {
        //            return result;
        //        }

        //        foreach (var item in response)
        //        {
        //            result.Add(ProjectMapper.ProjectToProjectDTO(item));
        //        }

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<ProjectDTO> GetByIdAsync(int id)
        //{
        //    try
        //    {
        //        ProjectDTO result;

        //        var response = await _unitOfWork.Repository<ProjectRepository>().GetByIdAsync(id);

        //        if (response is null)
        //        {
        //            result = new ProjectDTO();
        //            return result;
        //        }

        //        result = ProjectMapper.ProjectToProjectDTO(response);
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<ProjectResponseDTO> AddAsync(ProjectDTO projectDTO)
        //{
        //    try
        //    {
        //        ProjectResponseDTO result;

        //        if (projectDTO is null)
        //        {
        //            result = new ProjectResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        var entity = ProjectMapper.ProjectDTOToProject(projectDTO);

        //        await _unitOfWork.Repository<ProjectRepository>().AddAsync(entity);

        //        var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
        //        result = new ProjectResponseDTO() { IsOk = isOk };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<ProjectResponseDTO> UpdateAsync(int id, ProjectDTO projectDTO)
        //{
        //    try
        //    {
        //        ProjectResponseDTO result;

        //        if (id <= 0 || projectDTO is null)
        //        {
        //            result = new ProjectResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        var entity = await _unitOfWork.Repository<ProjectRepository>().GetByIdAsync(id);

        //        if (entity is null)
        //        {
        //            result = new ProjectResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        entity = ProjectMapper.ProjectDTOToProject(projectDTO, entity);

        //        _unitOfWork.Repository<ProjectRepository>().Update(entity);

        //        var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
        //        result = new ProjectResponseDTO() { IsOk = isOk };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<ProjectResponseDTO> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        ProjectResponseDTO result;

        //        if (id <= 0)
        //        {
        //            result = new ProjectResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        var entity = await _unitOfWork.Repository<ProjectRepository>().GetByIdAsync(id);

        //        if (entity is null)
        //        {
        //            result = new ProjectResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        _unitOfWork.Repository<ProjectRepository>().Delete(entity);

        //        var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
        //        result = new ProjectResponseDTO() { IsOk = isOk };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
    }
}

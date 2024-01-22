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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<List<EducationDTO>> GetAllAsync()
        //{
        //    try
        //    {
        //        var result = new List<EducationDTO>();

        //        var response = await _unitOfWork.Repository<EducationRepository>().GetAllAsync();
        //        response = response.OrderByDescending(t => t.StartDate);

        //        if (response is null)
        //        {
        //            return result;
        //        }

        //        foreach (var item in response)
        //        {
        //            result.Add(EducationMapper.EducationToEducationDTO(item));
        //        }

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<List<EducationDTO>> GetAllByAliasAsync(string alias)
        //{
        //    try
        //    {
        //        var result = new List<EducationDTO>();

        //        var response = await _unitOfWork.Repository<EducationRepository>().GetAllByAliasAsync(alias);
        //        response = response.OrderByDescending(t => t.StartDate);

        //        if (response is null)
        //        {
        //            return result;
        //        }

        //        foreach (var item in response)
        //        {
        //            result.Add(EducationMapper.EducationToEducationDTO(item));
        //        }

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<EducationDTO> GetByIdAsync(int id)
        //{
        //    try
        //    {
        //        EducationDTO result;

        //        var response = await _unitOfWork.Repository<EducationRepository>().GetByIdAsync(id);

        //        if (response is null)
        //        {
        //            result = new EducationDTO();
        //            return result;
        //        }

        //        result = EducationMapper.EducationToEducationDTO(response);
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<EducationResponseDTO> AddAsync(EducationDTO educationDTO)
        //{
        //    try
        //    {
        //        EducationResponseDTO result;

        //        if (educationDTO is null)
        //        {
        //            result = new EducationResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        var entity = EducationMapper.EducationDTOToEducation(educationDTO);

        //        await _unitOfWork.Repository<EducationRepository>().AddAsync(entity);

        //        var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;

        //        result = new EducationResponseDTO() { IsOk = isOk };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<EducationResponseDTO> UpdateAsync(int id, EducationDTO educationDTO)
        //{
        //    try
        //    {
        //        EducationResponseDTO result;

        //        if (id <= 0 || educationDTO is null)
        //        {
        //            result = new EducationResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        var entity = await _unitOfWork.Repository<EducationRepository>().GetByIdAsync(id);

        //        if (entity is not null)
        //        {
        //            result = new EducationResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        entity = EducationMapper.EducationDTOToEducation(educationDTO, entity);

        //        _unitOfWork.Repository<EducationRepository>().Update(entity);

        //        var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
        //        result = new EducationResponseDTO() { IsOk = isOk };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<EducationResponseDTO> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        EducationResponseDTO result;

        //        if (id <= 0)
        //        {
        //            result = new EducationResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        var entity = await _unitOfWork.Repository<EducationRepository>().GetByIdAsync(id);

        //        if (entity is null)
        //        {
        //            result = new EducationResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        _unitOfWork.Repository<EducationRepository>().Delete(entity);

        //        var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
        //        result = new EducationResponseDTO() { IsOk = isOk };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
    }
}

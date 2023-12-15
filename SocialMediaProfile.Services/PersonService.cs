using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services.Interfaces;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Core.Entities;

namespace SocialMediaProfile.Services
{
    public class PersonService : GenericService<Person, PersonDTO, PersonResponseDTO>, IPersonService
    {     
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task<List<PersonDTO>> GetAllAsync()
        //{
        //    try
        //    {
        //        var result = new List<PersonDTO>();

        //        var response = await _unitOfWork.Repository<PersonRepository>().GetAllAsync();

        //        if (response is null)
        //        {
        //            return result;
        //        }

        //        foreach (var item in response)
        //        {
        //            result.Add(PersonMapper.PersonToPersonDTO(item));
        //        }

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<List<PersonDTO>> GetAllByAliasAsync(string alias)
        //{
        //    try
        //    {
        //        var result = new List<PersonDTO>();

        //        var response = await _unitOfWork.Repository<PersonRepository>().GetAllByAliasAsync(alias);

        //        if (response is null)
        //        {
        //            return result;
        //        }

        //        foreach (var item in response)
        //        {
        //            result.Add(PersonMapper.PersonToPersonDTO(item));
        //        }

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<PersonDTO> GetByIdAsync(int id)
        //{
        //    try
        //    {
        //        PersonDTO result;

        //        var response = await _unitOfWork.Repository<PersonRepository>().GetByIdAsync(id);

        //        if (response is null)
        //        {
        //            result = new PersonDTO();
        //            return result;
        //        }

        //        result = PersonMapper.PersonToPersonDTO(response);
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<PersonResponseDTO> AddAsync(PersonDTO personDTO)
        //{
        //    try
        //    {
        //        PersonResponseDTO result;

        //        if (personDTO is null)
        //        {
        //            result = new PersonResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        var entity = PersonMapper.PersonDTOToPerson(personDTO);

        //        await _unitOfWork.Repository<PersonRepository>().AddAsync(entity);

        //        var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
        //        result = new PersonResponseDTO() { IsOk = isOk };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<PersonResponseDTO> UpdateAsync(int id, PersonDTO personDTO)
        //{
        //    try
        //    {
        //        PersonResponseDTO result;

        //        if (id <= 0 || personDTO is null)
        //        {
        //            result = new PersonResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        var entity = await _unitOfWork.Repository<PersonRepository>().GetByIdAsync(id);

        //        if (entity is null)
        //        {
        //            result = new PersonResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        entity = PersonMapper.PersonDTOToPerson(personDTO, entity);

        //        _unitOfWork.Repository<PersonRepository>().Update(entity);

        //        var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
        //        result = new PersonResponseDTO() { IsOk = isOk };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<PersonResponseDTO> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        PersonResponseDTO result;

        //        if (id <= 0)
        //        {
        //            result = new PersonResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        var entity = await _unitOfWork.Repository<PersonRepository>().GetByIdAsync(id);

        //        if (entity is null)
        //        {
        //            result = new PersonResponseDTO() { IsOk = false };
        //            return result;
        //        }

        //        _unitOfWork.Repository<PersonRepository>().Delete(entity);

        //        var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
        //        result = new PersonResponseDTO() { IsOk = isOk };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
    }
}

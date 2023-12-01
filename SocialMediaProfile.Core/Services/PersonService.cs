using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;
using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PersonDTO>> GetAllAsync()
        {
            try
            {
                var result = new List<PersonDTO>();

                var response = await _unitOfWork.PersonRepository.GetAllAsync();

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(PersonMapper.PersonToPersonDTO(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<PersonDTO>> GetAllByAliasAsync(string alias)
        {
            try
            {
                var result = new List<PersonDTO>();

                var response = await _unitOfWork.PersonRepository.GetAllByAliasAsync(alias);

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(PersonMapper.PersonToPersonDTO(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PersonDTO> GetByIdAsync(int id)
        {
            try
            {
                PersonDTO result;

                var response = await _unitOfWork.PersonRepository.GetByIdAsync(id);

                if (response is null)
                {
                    result = new PersonDTO();
                    return result;
                }

                result = PersonMapper.PersonToPersonDTO(response);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PersonResponseDTO> AddAsync(PersonDTO personDTO)
        {
            try
            {
                PersonResponseDTO result;

                if (personDTO is null)
                {
                    result = new PersonResponseDTO() { IsOk = false };
                    return result;
                }

                var entity = PersonMapper.PersonDTOToPerson(personDTO);

                await _unitOfWork.PersonRepository.AddAsync(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
                result = new PersonResponseDTO() { IsOk = isOk };

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PersonResponseDTO> UpdateAsync(int id, PersonDTO personDTO)
        {
            try
            {
                PersonResponseDTO result;

                if (id <= 0 || personDTO is null)
                {
                    result = new PersonResponseDTO() { IsOk = false };
                    return result;
                }

                var entity = await _unitOfWork.PersonRepository.GetByIdAsync(id);

                if (entity is null)
                {
                    result = new PersonResponseDTO() { IsOk = false };
                    return result;
                }

                entity = PersonMapper.PersonDTOToPerson(personDTO, entity);

                _unitOfWork.PersonRepository.Update(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
                result = new PersonResponseDTO() { IsOk = isOk };

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PersonResponseDTO> DeleteAsync(int id)
        {
            try
            {
                PersonResponseDTO result;

                if (id <= 0)
                {
                    result = new PersonResponseDTO() { IsOk = false };
                    return result;
                }

                var entity = await _unitOfWork.PersonRepository.GetByIdAsync(id);

                if (entity is null)
                {
                    result = new PersonResponseDTO() { IsOk = false };
                    return result;
                }

                _unitOfWork.PersonRepository.Delete(entity);

                var isOk = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;
                result = new PersonResponseDTO() { IsOk = isOk };

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

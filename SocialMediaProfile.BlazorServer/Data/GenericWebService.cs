using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class GenericWebService<TDTO, TResponseDTO> : IGenericWebService<TDTO, TResponseDTO>
        where TDTO : class
        where TResponseDTO : class
    {
        private readonly IGlobalWebService _globalWebService;
        private readonly string _endpoint;

        public GenericWebService(IGlobalWebService globalWebService, string endpoint)
        {
            _globalWebService = globalWebService;
            _endpoint = endpoint;
        }

        public async Task<List<TDTO>> GetAllAsync()
        {
            try
            {
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<TDTO>>(_endpoint);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<TDTO>> GetAllByAliasAsync(string alias)
        {
            try
            {
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<TDTO>>($"{_endpoint}/alias/{alias}");
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TResponseDTO> AddAsync(TDTO dto)
        {
            try
            {
                TResponseDTO result;

                dto.GetType().GetProperty("UserId")?.SetValue(dto, _globalWebService.UserId);

                var response = await _globalWebService.HttpClient.PostAsJsonAsync(_endpoint + "/add", dto);

                if (!response.IsSuccessStatusCode)
                {
                    result = Activator.CreateInstance<TResponseDTO>();
                    (result as ExperienceResponseDTO)?.SetStatusCode(response.StatusCode);
                    return result;
                }

                result = await response.Content.ReadFromJsonAsync<TResponseDTO>();
                (result as ExperienceResponseDTO)?.SetStatusCode(response.StatusCode);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TResponseDTO> UpdateAsync(TDTO dto)
        {
            try
            {
                TResponseDTO result;

                dto.GetType().GetProperty("UserId")?.SetValue(dto, _globalWebService.UserId);

                var response = await _globalWebService.HttpClient.PutAsJsonAsync($"{_endpoint}/{dto.GetType().GetProperty("Id")?.GetValue(dto)}", dto);

                if (!response.IsSuccessStatusCode)
                {
                    result = Activator.CreateInstance<TResponseDTO>();
                    (result as ExperienceResponseDTO)?.SetStatusCode(response.StatusCode);
                    return result;
                }

                result = await response.Content.ReadFromJsonAsync<TResponseDTO>();
                (result as ExperienceResponseDTO)?.SetStatusCode(response.StatusCode);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TResponseDTO> DeleteAsync(int id)
        {
            try
            {
                TResponseDTO result;

                var response = await _globalWebService.HttpClient.DeleteAsync($"{_endpoint}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    result = Activator.CreateInstance<TResponseDTO>();
                    (result as ExperienceResponseDTO)?.SetStatusCode(response.StatusCode);
                    return result;
                }

                result = await response.Content.ReadFromJsonAsync<TResponseDTO>();
                (result as ExperienceResponseDTO)?.SetStatusCode(response.StatusCode);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
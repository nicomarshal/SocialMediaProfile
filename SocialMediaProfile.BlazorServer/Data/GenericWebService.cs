using SocialMediaProfile.BlazorServer.Data.Interfaces;


namespace SocialMediaProfile.BlazorServer.Data
{
    public class GenericWebService<TDTO, TResultDTO> : IGenericWebService<TDTO, TResultDTO>
        where TDTO : class
        where TResultDTO : class
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
                var endpoint = $"{_endpoint}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<TDTO>>(endpoint);
                
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
                var endpoint = $"{_endpoint}/alias/{alias}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<TDTO>>(endpoint);
                
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TResultDTO> AddAsync(TDTO tDTO)
        {
            try
            {
                TResultDTO tResultDTO;

                var endpoint = $"{_endpoint}/add";
                tDTO.GetType().GetProperty("UserId").SetValue(tDTO, _globalWebService.UserId);

                var response = await _globalWebService.HttpClient.PostAsJsonAsync(endpoint, tDTO);

                if (!response.IsSuccessStatusCode)
                {
                    tResultDTO = Activator.CreateInstance<TResultDTO>();
                    tResultDTO.GetType().GetProperty("StatusCode").SetValue(tResultDTO, response.StatusCode);
                    
                    return tResultDTO;
                }

                tResultDTO = await response.Content.ReadFromJsonAsync<TResultDTO>();
                tResultDTO.GetType().GetProperty("StatusCode").SetValue(tResultDTO, response.StatusCode);
                
                return tResultDTO;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TResultDTO> UpdateAsync(TDTO tDTO)
        {
            try
            {
                TResultDTO tResultDTO;

                var id = tDTO.GetType().GetProperty("Id").GetValue(tDTO);

                var endpoint = $"{_endpoint}/{id}";              
                tDTO.GetType().GetProperty("UserId").SetValue(tDTO, _globalWebService.UserId);

                var response = await _globalWebService.HttpClient.PutAsJsonAsync(endpoint, tDTO);

                if (!response.IsSuccessStatusCode)
                {
                    tResultDTO = Activator.CreateInstance<TResultDTO>();
                    tResultDTO.GetType().GetProperty("StatusCode").SetValue(tResultDTO, response.StatusCode);
                    return tResultDTO;
                }

                tResultDTO = await response.Content.ReadFromJsonAsync<TResultDTO>();
                tResultDTO.GetType().GetProperty("StatusCode").SetValue(tResultDTO, response.StatusCode);
                return tResultDTO;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TResultDTO> DeleteAsync(int id)
        {
            try
            {
                TResultDTO tResultDTO;

                var endpoint = $"{_endpoint}/{id}";

                var response = await _globalWebService.HttpClient.DeleteAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    tResultDTO = Activator.CreateInstance<TResultDTO>();
                    tResultDTO.GetType().GetProperty("StatusCode").SetValue(tResultDTO, response.StatusCode);
                    return tResultDTO;
                }

                tResultDTO = await response.Content.ReadFromJsonAsync<TResultDTO>();
                tResultDTO.GetType().GetProperty("StatusCode").SetValue(tResultDTO, response.StatusCode);
                return tResultDTO;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
using SocialMediaProfile.BlazorServer.Data.Interfaces;


namespace SocialMediaProfile.BlazorServer.Data
{
    public class GenericWebService<TDTO, TResultDTO> : IGenericWebService<TDTO, TResultDTO>
        where TDTO : class
        where TResultDTO : class
    {
        protected readonly IGlobalWebService _globalWebService;
        public string Endpoint { get; set; }

        public GenericWebService(IGlobalWebService globalWebService)
        {
            _globalWebService = globalWebService;
        }

        public async Task<List<TDTO>> GetAllAsync()
        {
            try
            {
                var endpoint = $"{Endpoint}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<TDTO>>(endpoint);
                
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TDTO> GetByIdAsync(int id)
        {
            try
            {
                var endpoint = $"{Endpoint}/{id}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<TDTO>(endpoint);

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

                var endpoint = $"{Endpoint}";
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

                var endpoint = $"{Endpoint}";              
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

                var endpoint = $"{Endpoint}/{id}";

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
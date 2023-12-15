namespace SocialMediaProfile.Services.Interfaces
{
    public interface IGenericService<TEntity, TDTO, TResponseDTO>
        where TEntity : class
        where TDTO : class
        where TResponseDTO : class
    {
        Task<List<TDTO>> GetAllAsync();
        Task<List<TDTO>> GetAllByAliasAsync(string alias);
        Task<TDTO> GetByIdAsync(int id);
        Task<TResponseDTO> AddAsync(TDTO dto);
        Task<TResponseDTO> UpdateAsync(int id, TDTO dto);
        Task<TResponseDTO> DeleteAsync(int id);
    }
}

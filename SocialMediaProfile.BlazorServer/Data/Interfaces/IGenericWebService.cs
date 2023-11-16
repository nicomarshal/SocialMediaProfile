using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGenericWebService<TDTO, TResponseDTO>
    where TDTO : class
    where TResponseDTO : class
{
    Task<List<TDTO>> GetAllAsync();
    Task<List<TDTO>> GetAllByAliasAsync(string alias);
    Task<TResponseDTO> AddAsync(TDTO dto);
    Task<TResponseDTO> UpdateAsync(TDTO dto);
    Task<TResponseDTO> DeleteAsync(int id);
}


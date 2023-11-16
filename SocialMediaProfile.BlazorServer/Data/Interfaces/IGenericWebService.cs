using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGenericWebService<TDTO, TResultDTO>
    where TDTO : class
    where TResultDTO : class
{
    Task<List<TDTO>> GetAllAsync();
    Task<List<TDTO>> GetAllByAliasAsync(string alias);
    Task<TResultDTO> AddAsync(TDTO dto);
    Task<TResultDTO> UpdateAsync(TDTO dto);
    Task<TResultDTO> DeleteAsync(int id);
}


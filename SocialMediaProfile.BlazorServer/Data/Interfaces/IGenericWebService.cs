using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGenericWebService<TDTO, TResultDTO>
    where TDTO : class
    where TResultDTO : class
{
    string Endpoint { get; set; }
    Task<List<TDTO>> GetAllAsync();
    Task<TDTO> GetByIdAsync(int id);
    Task<TResultDTO> AddAsync(TDTO dto);
    Task<TResultDTO> UpdateAsync(TDTO dto);
    Task<TResultDTO> DeleteAsync(int id);
}


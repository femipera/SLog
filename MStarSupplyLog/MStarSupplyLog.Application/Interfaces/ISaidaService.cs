using MStarSupplyLog.Application.DTOs;

namespace MStarSupplyLog.Application.Interfaces
{
    public interface ISaidaService
    {
        Task<IEnumerable<SaidaDTO>> GetAllAsync();
        Task<SaidaDTO> GetByIdAsync(int? id);
        Task<IEnumerable<SaidaDTO>> GetByDateAsync(DateTime data);
        Task<SaidaDTO> GetSaidaMercadoriaAsync(int? id);
        Task AddAsync(SaidaDTO saidaDTO);
        Task UpdateAsync(SaidaDTO saidaDTO);
        Task RemoveAsync(int? id);
    }
}

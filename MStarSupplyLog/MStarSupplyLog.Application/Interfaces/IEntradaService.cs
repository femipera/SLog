using MStarSupplyLog.Application.DTOs;

namespace MStarSupplyLog.Application.Interfaces
{
    public interface IEntradaService
    {
        Task<IEnumerable<EntradaDTO>> GetAllAsync();
        Task<EntradaDTO> GetByIdAsync(int? id);
        Task<IEnumerable<EntradaDTO>> GetByDateAsync(DateTime data);
        Task<EntradaDTO> GetSaidaMercadoriaAsync(int? id);
        Task AddAsync(EntradaDTO entradaDTO);
        Task UpdateAsync(EntradaDTO entradaDTO);
        Task RemoveAsync(int? id);
    }
}

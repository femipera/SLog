using MStarSupplyLog.Application.DTOs;

namespace MStarSupplyLog.Application.Interfaces
{
    public interface IFabricanteService
    {
        Task<IEnumerable<FabricanteDTO>> GetAllAsync();
        Task<FabricanteDTO> GetByIdAsync(int? id);
        Task AddAsync(FabricanteDTO fabricanteDTO);
        Task UpdateAsync(FabricanteDTO fabricanteDTO);
        Task RemoveAsync(int? id);
    }
}

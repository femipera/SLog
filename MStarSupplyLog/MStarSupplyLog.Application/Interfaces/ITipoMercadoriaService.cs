using MStarSupplyLog.Application.DTOs;

namespace MStarSupplyLog.Application.Interfaces
{
    public interface ITipoMercadoriaService
    {
        Task<IEnumerable<TipoMercadoriaDTO>> GetAllAsync();
        Task<TipoMercadoriaDTO> GetByIdAsync(int? id);
        Task AddAsync(TipoMercadoriaDTO tipoMercadoriaDTO);
        Task UpdateAsync(TipoMercadoriaDTO tipoMercadoriaDTO);
        Task RemoveAsync(int? id);
    }
}

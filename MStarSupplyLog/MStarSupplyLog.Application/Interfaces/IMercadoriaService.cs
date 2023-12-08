using MStarSupplyLog.Application.DTOs;

namespace MStarSupplyLog.Application.Interfaces
{
    public interface IMercadoriaService
    {
        Task<IEnumerable<MercadoriaDTO>> GetAllAsync();
        Task<MercadoriaDTO> GetByIdAsync(int? id);
        Task<MercadoriaDTO> GetMercadoriaFabricanteAsync(int? id);
        Task<MercadoriaDTO> GetMercadoriaTipoMercadoriaAsync(int? id);       
        Task AddAsync(MercadoriaDTO mercadoriaDTO);
        Task UpdateAsync(MercadoriaDTO mercadoriaDTO);
        Task RemoveAsync(int? id);
    }
}

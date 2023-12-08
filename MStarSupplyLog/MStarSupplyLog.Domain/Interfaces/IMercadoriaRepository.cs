using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Domain.Interfaces
{
    public interface IMercadoriaRepository
    {
        Task<IEnumerable<Mercadoria>> GetAllAsync();
        Task<Mercadoria> GetByIdAsync(int? id);
        Task<Mercadoria> GetMercadoriaFabricanteAsync(int? id);
        Task<Mercadoria> GetMercadoriaTipoAsync(int? id);
        Task<Mercadoria> CreateAsync(Mercadoria mercadoria);
        Task<Mercadoria> UpdateAsync(Mercadoria mercadoria);
        Task<Mercadoria> RemoveAsync(Mercadoria mercadoria);
    }
}

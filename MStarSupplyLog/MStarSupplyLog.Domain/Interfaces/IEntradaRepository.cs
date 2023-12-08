using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Domain.Interfaces
{
    public interface IEntradaRepository
    {
        Task<IEnumerable<Entrada>> GetAllAsync();
        Task<Entrada> GetByIdAsync(int? id);
        Task<IEnumerable<Entrada>> GetByDateAsync(DateTime data);
        Task<Entrada> CreateAsync(Entrada entrada);
        Task<Entrada> UpdateAsync(Entrada entrada);
        Task<Entrada> RemoveAsync(Entrada entrada);
        Task<Entrada> GetEntradaMercadoriaAsync(int? id);   
    }
}

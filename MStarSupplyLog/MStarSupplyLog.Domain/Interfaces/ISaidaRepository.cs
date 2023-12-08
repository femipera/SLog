using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Domain.Interfaces
{
    public interface ISaidaRepository
    {
        Task<IEnumerable<Saida>> GetAllAsync();
        Task<Saida> GetByIdAsync(int? id);
        Task<IEnumerable<Saida>> GetByDateAsync(DateTime data);
        Task<Saida> CreateAsync(Saida saida);
        Task<Saida> UpdateAsync(Saida saida);
        Task<Saida> RemoveAsync(Saida saida);
        Task<Saida> GetSaidaMercadoriaAsync(int? id);

    }
}

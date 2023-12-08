using MStarSupplyLog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupplyLog.Domain.Interfaces
{
    public interface ITipoMercadoriaRepository
    {
        Task<IEnumerable<TipoMercadoria>> GetAllAsync();
        Task<TipoMercadoria> GetByIdAsync(int? id);
        Task<TipoMercadoria> CreateAsync(TipoMercadoria tipoMercadoria);
        Task<TipoMercadoria> UpdateAsync(TipoMercadoria tipoMercadoria);
        Task<TipoMercadoria> RemoveAsync(TipoMercadoria tipoMercadoria);
    }
}

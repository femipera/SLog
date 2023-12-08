using MStarSupplyLog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupplyLog.Domain.Interfaces
{
    public interface IFabricanteRepository
    {
        Task<IEnumerable<Fabricante>> GetAllAsync();
        Task<Fabricante> GetByIdAsync(int? id);
        Task<Fabricante> CreateAsync(Fabricante fabricante);
        Task<Fabricante> UpdateAsync(Fabricante fabricante);
        Task<Fabricante> RemoveAsync(Fabricante fabricante);
    }
}

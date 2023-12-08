using Microsoft.EntityFrameworkCore;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;
using MStarSupplyLog.Infra.Data.Context;

namespace MStarSupplyLog.Infra.Data.Repositories
{
    public class FabricanteRepository : IFabricanteRepository
    {
        readonly AppDbContext _context;

        public FabricanteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Fabricante> CreateAsync(Fabricante fabricante)
        {
            _context.Fabricantes.Add(fabricante);
            await _context.SaveChangesAsync();
            return fabricante;
        }

        public async Task<IEnumerable<Fabricante>> GetAllAsync()
        {
            return await _context.Fabricantes.ToListAsync();
        }

        public async Task<Fabricante> GetByIdAsync(int? id)
        {
            return await _context.Fabricantes.FindAsync(id);
        }

        public async Task<Fabricante> RemoveAsync(Fabricante fabricante)
        {
            _context.Fabricantes.Remove(fabricante);
            await _context.SaveChangesAsync();
            return fabricante;
        }

        public async Task<Fabricante> UpdateAsync(Fabricante fabricante)
        {
            _context.Fabricantes.Update(fabricante);
            await _context.SaveChangesAsync();
            return fabricante;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;
using MStarSupplyLog.Infra.Data.Context;

namespace MStarSupplyLog.Infra.Data.Repositories
{
    public class SaidaRepository : ISaidaRepository
    {
        private readonly AppDbContext _context;

        public SaidaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Saida> CreateAsync(Saida saida)
        {
            _context.Saidas.Add(saida);
            await _context.SaveChangesAsync();
            return saida;
        }

        public async Task<IEnumerable<Saida>> GetAllAsync()
        {
            return await _context.Saidas.ToListAsync();
        }

        public async Task<Saida> GetByIdAsync(int? id)
        {
            return await _context.Saidas.FindAsync(id);
        }

        public async Task<Saida> GetSaidaMercadoriaAsync(int? id)
        {
            return await _context.Saidas.Include(m => m.Mercadoria).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Saida>> GetByDateAsync(DateTime data)
        {
            return await _context.Saidas
                  .Where(e => e.DataHora.Year == data.Year && e.DataHora.Month == data.Month).ToListAsync();
        }

        public async Task<Saida> RemoveAsync(Saida saida)
        {
            _context.Saidas.Remove(saida);
            await _context.SaveChangesAsync();
            return saida;
        }

        public async Task<Saida> UpdateAsync(Saida saida)
        {
            _context.Saidas.Update(saida);
            await _context.SaveChangesAsync();
            return saida;
        }
    }
}

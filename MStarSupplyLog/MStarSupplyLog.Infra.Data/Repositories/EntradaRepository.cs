using Microsoft.EntityFrameworkCore;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;
using MStarSupplyLog.Infra.Data.Context;

namespace MStarSupplyLog.Infra.Data.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly AppDbContext _context;

        public EntradaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Entrada> CreateAsync(Entrada entrada)
        {
            _context.Entradas.Add(entrada);
            await _context.SaveChangesAsync();
            return entrada;
        }

        public async Task<IEnumerable<Entrada>> GetAllAsync()
        {
            return await _context.Entradas.ToListAsync();
        }

        public async Task<IEnumerable<Entrada>> GetByDateAsync(DateTime data)
        {
            return await _context.Entradas
                  .Where(e => e.DataHora.Year == data.Year && e.DataHora.Month == data.Month).ToListAsync();
        }

        public async Task<Entrada> GetByIdAsync(int? id)
        {
            return await _context.Entradas.FindAsync(id);
        }

        public async Task<Entrada> GetEntradaMercadoriaAsync(int? id)
        {
            return await _context.Entradas.Include(m => m.Mercadoria).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Entrada> RemoveAsync(Entrada entrada)
        {
            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();
            return entrada;
        }

        public async Task<Entrada> UpdateAsync(Entrada entrada)
        {
            _context.Entradas.Update(entrada);
            await _context.SaveChangesAsync();
            return entrada;
        }
    }
}

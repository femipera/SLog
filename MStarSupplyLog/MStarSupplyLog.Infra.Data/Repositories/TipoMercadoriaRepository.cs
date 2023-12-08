using Microsoft.EntityFrameworkCore;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;
using MStarSupplyLog.Infra.Data.Context;

namespace MStarSupplyLog.Infra.Data.Repositories
{
    public class TipoMercadoriaRepository : ITipoMercadoriaRepository
    {
        readonly AppDbContext _context;
        public TipoMercadoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TipoMercadoria> CreateAsync(TipoMercadoria tipoMercadoria)
        {
            _context.TipoMercadorias.Add(tipoMercadoria);
            await _context.SaveChangesAsync();
            return tipoMercadoria;
        }

        public async Task<IEnumerable<TipoMercadoria>> GetAllAsync()
        {
            return await _context.TipoMercadorias.ToListAsync();
        }

        public async Task<TipoMercadoria> GetByIdAsync(int? id)
        {
            return await _context.TipoMercadorias.FindAsync(id);
        }

        public async Task<TipoMercadoria> RemoveAsync(TipoMercadoria tipoMercadoria)
        {
            _context.TipoMercadorias.Remove(tipoMercadoria);
            await _context.SaveChangesAsync();
            return tipoMercadoria;
        }

        public async Task<TipoMercadoria> UpdateAsync(TipoMercadoria tipoMercadoria)
        {
            _context.TipoMercadorias.Update(tipoMercadoria);
            await _context.SaveChangesAsync();
            return tipoMercadoria;
        }
    }
}

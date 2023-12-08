using Microsoft.EntityFrameworkCore;
using MStarSupplyLog.Domain.Entities;
using MStarSupplyLog.Domain.Interfaces;
using MStarSupplyLog.Infra.Data.Context;

namespace MStarSupplyLog.Infra.Data.Repositories
{
    public class MercadoriaRepository : IMercadoriaRepository
    {
        private readonly AppDbContext _context;

        public MercadoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Mercadoria> CreateAsync(Mercadoria mercadoria)
        {
            _context.Mercadorias.Add(mercadoria);
            await _context.SaveChangesAsync();
            return mercadoria;        
        }

        public async Task<IEnumerable<Mercadoria>> GetAllAsync()
        {
            return await _context.Mercadorias.ToListAsync();          
        }

        public async Task<Mercadoria> GetByIdAsync(int? id)
        {
            return await _context.Mercadorias.FindAsync(id);
        }

        public async Task<Mercadoria> GetMercadoriaFabricanteAsync(int? id)
        {
            return await _context.Mercadorias.Include(f => f.Fabricante).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Mercadoria> GetMercadoriaTipoAsync(int? id)
        {
            return await _context.Mercadorias.Include(t => t.TipoMercadoria).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Mercadoria> RemoveAsync(Mercadoria mercadoria)
        {
            _context.Mercadorias.Remove(mercadoria);
            await _context.SaveChangesAsync();
            return mercadoria;
        }

        public async Task<Mercadoria> UpdateAsync(Mercadoria mercadoria)
        {
            _context.Mercadorias.Update(mercadoria);
            await _context.SaveChangesAsync();
            return mercadoria;
        }
    }
}

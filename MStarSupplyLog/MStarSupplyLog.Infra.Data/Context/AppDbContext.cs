using Microsoft.EntityFrameworkCore;
using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<TipoMercadoria> TipoMercadorias { get; set; }
        public DbSet<Mercadoria> Mercadorias { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Saida> Saidas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

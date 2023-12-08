using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Infra.Data.EntitiesBuilder
{
    public class MercadoriaBuilder : IEntityTypeConfiguration<Mercadoria>
   {
        public void Configure(EntityTypeBuilder<Mercadoria> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Descricao).IsRequired().HasMaxLength(500);
            builder.HasOne(m => m.Fabricante).WithMany(f => f.Mercadorias).HasForeignKey(m => m.FabricanteId);
            builder.HasOne(m => m.TipoMercadoria).WithMany(tm => tm.Mercadorias).HasForeignKey(m => m.TipoMercadoriaId);
        }
    }
}

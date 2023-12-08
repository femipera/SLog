using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Infra.Data.EntitiesConfiguration
{
    public class TipoMercadoriaBuilder : IEntityTypeConfiguration<TipoMercadoria>
    {
        public void Configure(EntityTypeBuilder<TipoMercadoria> builder)
        {
            builder.HasKey(tm => tm.Id);
            builder.Property(tm => tm.Nome).IsRequired().HasMaxLength(200);
        }
    }
}

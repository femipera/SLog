using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStarSupplyLog.Domain.Entities;


namespace MStarSupplyLog.Infra.Data.EntitiesBuilder
{
    public class SaidaBuilder : IEntityTypeConfiguration<Saida>
    {
        public void Configure(EntityTypeBuilder<Saida> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Local).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Quantidade).IsRequired();
            builder.Property(e => e.DataHora).IsRequired();
            builder.HasOne(m => m.Mercadoria).WithMany(e => e.Saidas).HasForeignKey(m => m.MercadoriaId);
        }
    }
}

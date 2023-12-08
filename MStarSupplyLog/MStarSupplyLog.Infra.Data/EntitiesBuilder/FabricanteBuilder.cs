using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Infra.Data.EntitiesBuilder
{

    public class FabricanteBuilder : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Nome).IsRequired().HasMaxLength(100);
        }
    }
}

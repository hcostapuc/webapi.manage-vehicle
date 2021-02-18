using domain.manage_vehicle.Entity;
using domain.manage_vehicle.Entity.Venda;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace domain.manage_vehicle.Maps
{
    public class VendaMap
    {
        public VendaMap(EntityTypeBuilder<VendaEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => p.Codigo);
            entityTypeBuilder.Property(p => p.Data);

            entityTypeBuilder.HasMany(vd => vd.Veiculos)
                .WithOne(vl => vl.Venda);

            entityTypeBuilder.HasOne(vd => vd.Vendedor)
                .WithOne(vo => vo.Venda)
                .HasForeignKey<VendedorEntity>(voe => voe.Codigo);
        }
    }
}

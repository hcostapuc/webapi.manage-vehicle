using domain.manage_vehicle.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace domain.manage_vehicle.Maps
{
    public class VeiculoMap
    {
        public VeiculoMap(EntityTypeBuilder<VeiculoEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => p.Codigo);
            entityTypeBuilder.Property(p => p.AnoFabricacao);
            entityTypeBuilder.Property(p => p.Marca);
            entityTypeBuilder.Property(p => p.Modelo);
        }
    }
}

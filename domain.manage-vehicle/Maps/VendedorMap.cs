using domain.manage_vehicle.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace domain.manage_vehicle.Maps
{
    public class VendedorMap
    {
        public VendedorMap(EntityTypeBuilder<VendedorEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => p.Codigo);
            entityTypeBuilder.Property(p => p.Cpf);
            entityTypeBuilder.Property(p => p.Email);
            entityTypeBuilder.Property(p => p.Nome);
        }
    }
}

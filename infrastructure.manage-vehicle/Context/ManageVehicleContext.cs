using domain.manage_vehicle.Entity;
using domain.manage_vehicle.Entity.Venda;
using domain.manage_vehicle.Maps;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.manage_vehicle.Context
{
    public class ManageVehicleContext : DbContext
    {
        public ManageVehicleContext(DbContextOptions<ManageVehicleContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new VendaMap(modelBuilder.Entity<VendaEntity>());
            new VeiculoMap(modelBuilder.Entity<VeiculoEntity>());
            new VendedorMap(modelBuilder.Entity<VendedorEntity>());
        }
    }
}

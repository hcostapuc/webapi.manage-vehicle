using domain.manage_vehicle.Entity.Venda;
using infrastructure.manage_vehicle.Context;
using infrastructure.manage_vehicle.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace infrastructure.manage_vehicle.Repositories
{
    public class VendaRepository : BaseRepository<VendaEntity>, IVendaRepository
    {
        private readonly ManageVehicleContext context;
        public VendaRepository(ManageVehicleContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<VendaEntity> GetIncludeAllAsync(Guid id)
        {
            return await context.Set<VendaEntity>()
                                .Include(ven => ven.Vendedor)
                                .Include(vei => vei.Veiculos)
                                .SingleOrDefaultAsync(e => e.Codigo == id);
        }
    }
}

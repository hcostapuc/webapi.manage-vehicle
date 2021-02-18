using domain.manage_vehicle.Entity.Venda;
using infrastructure.manage_vehicle.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.manage_vehicle.Interfaces
{
    public interface IVendaRepository : IBaseRepository<VendaEntity>
    {
        Task<VendaEntity> GetIncludeAllAsync(Guid id);
    }
}

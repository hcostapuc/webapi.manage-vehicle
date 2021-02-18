using domain.manage_vehicle.Entity.Venda;
using System;
using System.Threading.Tasks;

namespace infrastructure.manage_vehicle.Interfaces
{
    public interface IVendaRepository : IBaseRepository<VendaEntity>
    {
        Task<VendaEntity> GetIncludeAllAsync(Guid id);
    }
}

using domain.manage_vehicle.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infrastructure.manage_vehicle.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}

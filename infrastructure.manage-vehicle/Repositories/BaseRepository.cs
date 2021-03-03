using domain.manage_vehicle.Entities;
using infrastructure.manage_vehicle.Context;
using infrastructure.manage_vehicle.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infrastructure.manage_vehicle.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ManageVehicleContext context;
        private readonly DbSet<T> entities;
        public BaseRepository(ManageVehicleContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            entities = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await entities.ToListAsync();

        public async Task<T> GetAsync(Guid id) =>
            await entities.SingleOrDefaultAsync(e => e.Codigo == id);

        public async Task UpdateAsync(T entity) =>
            await context.SaveChangesAsync();
    }
}
